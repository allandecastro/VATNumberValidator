import { IInputs, IOutputs } from "./generated/ManifestTypes";

export class VATNumberValidator implements ComponentFramework.StandardControl<IInputs, IOutputs> {

	private _context: ComponentFramework.Context<IInputs>;
	private _container: HTMLDivElement;
	private _notifyOutputChanged: () => void;

	private _vatNumberElement: HTMLInputElement;
	private _vatNumberTypeElement: HTMLElement;
	private _vatNumberChanged: EventListenerOrEventListenerObject;

	private _vatNumber: string;
	private _companyName: string;
	private _companyAddress: string;
	private _isValid: boolean;
	/**
	 * Empty constructor.
	 */
	constructor() {

	}

	/**
	 * Used to initialize the control instance. Controls can kick off remote server calls and other initialization actions here.
	 * Data-set values are not initialized here, use updateView.
	 * @param context The entire property bag available to control via Context Object; It contains values as set up by the customizer mapped to property names defined in the manifest, as well as utility functions.
	 * @param notifyOutputChanged A callback method to alert the framework that the control has new outputs ready to be retrieved asynchronously.
	 * @param state A piece of data that persists in one session for a single user. Can be set at any point in a controls life cycle by calling 'setControlState' in the Mode interface.
	 * @param container If a control is marked control-type='standard', it will receive an empty div element within which it can render its content.
	 */
	public init(context: ComponentFramework.Context<IInputs>, notifyOutputChanged: () => void, state: ComponentFramework.Dictionary, container: HTMLDivElement) {
		// Add control initialization code
		this._context = context;
		this._container = container;
		this._notifyOutputChanged = notifyOutputChanged;
		this._vatNumberChanged = this.vatNumberChanged.bind(this);

		this._vatNumber = this._context.parameters.vatNumberfield == null || this._context.parameters.vatNumberfield.raw == null ? "" : this._context.parameters.vatNumberfield.raw;
		this._companyName = this._context.parameters.companyName == null || this._context.parameters.companyName.raw == null ? "" : this._context.parameters.companyName.raw;
		this._companyAddress = this._context.parameters.companyAddress == null || this._context.parameters.companyAddress.raw == null ? "" : this._context.parameters.companyAddress.raw;

		this._container = document.createElement("div");
		container.appendChild(this._container);
		this._vatNumberElement = document.createElement("input");
		this._vatNumberElement.setAttribute("type", "text");
		this._vatNumberElement.setAttribute("class", "pcfvatinputcontrol");
		this._vatNumberElement.addEventListener("change", this._vatNumberChanged);
		this._vatNumberTypeElement = document.createElement("img");
		this._vatNumberTypeElement.setAttribute("class", "pcfvatimagecontrol");
		this._vatNumberTypeElement.setAttribute("height", "24px");
		this._container.appendChild(this._vatNumberElement);
		this._container.appendChild(this._vatNumberTypeElement);
	}
	/**
	* Called when a change is detected in the phone number input.
	*/
	private vatNumberChanged(evt: Event): void {
		this.CheckVatNumber();
		this._notifyOutputChanged();
	}

	/**
	 * Called when any value in the property bag has changed. This includes field values, data-sets, global values such as container height and width, offline status, control metadata values such as label, visible, etc.
	 * @param context The entire property bag available to control via Context Object; It contains values as set up by the customizer mapped to names defined in the manifest, as well as utility functions
	 */
	public updateView(context: ComponentFramework.Context<IInputs>): void {
		let visible = this._context.mode.isVisible;
		if (visible) {
			this.SecurityEnablement(this._vatNumberElement);
			this._vatNumber = this._context.parameters.vatNumberfield == null || this._context.parameters.vatNumberfield.raw == null ? "" : this._context.parameters.vatNumberfield.raw;
			if (this._vatNumber != null && this._vatNumber.length > 0) {
				this._vatNumberElement.value = this._vatNumber;
				this.CheckVatNumber();
				this._notifyOutputChanged();
			}
		}
	}
	/**
	 * Used to implement the security model about the targeted field
	 * @param _vatNumberElement The entire property bag available to control via Context Object; It contains values as set up by the customizer mapped to property names defined in the manifest, as well as utility functions.
	 */
	private SecurityEnablement(_vatNumberElement: HTMLInputElement): void {

		let readOnly = this._context.mode.isControlDisabled; // If the form is diabled because it is inactive or the user doesn't have access isControlDisabled is set to true
		// When a field has FLS enabled, the security property on the attribute parameter is set
		let masked = false;
		if (this._context.parameters.vatNumberfield.security) {
			readOnly = readOnly || !this._context.parameters.vatNumberfield.security.editable;
			masked = !this._context.parameters.vatNumberfield.security.readable;
		}
		if (masked)
			this._vatNumberElement.setAttribute("placeholder", "*******");
		else
			this._vatNumberElement.setAttribute("placeholder", "Insert a VAT Number..");
		if (readOnly)
			this._vatNumberElement.readOnly = true;
		else
			this._vatNumberElement.readOnly = false;
	}

	/**
	 * Used to query the SOAP services and set the result to the appropriate fields.
	 */
	private CheckVatNumber(): void {
		this._vatNumber = this._vatNumberElement.value;
		if (this._vatNumber.length > 0) {
			var xmlhttp = new XMLHttpRequest();
			xmlhttp.open('POST', 'https://cors-anywhere.herokuapp.com/https://euvat-cors-reverse-proxy.glitch.me/vies', true);
			// build SOAP request
			var soadpRequest: string = "<?xml version='1.0' encoding='UTF-8'?>" +
				"<SOAP-ENV:Envelope xmlns:ns0='urn:ec.europa.eu:taxud:vies:services:checkVat:types'" +
				" xmlns:ns1='http://schemas.xmlsoap.org/soap/envelope/'" +
				" xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance'" +
				" xmlns:SOAP-ENV='http://schemas.xmlsoap.org/soap/envelope/'>" +
				"<SOAP-ENV:Header/><ns1:Body><ns0:checkVat>" +
				"<ns0:countryCode>" + this._vatNumber.slice(0, 2).toUpperCase() + "</ns0:countryCode>" +
				"<ns0:vatNumber>" + this._vatNumber.slice(2) + "</ns0:vatNumber>" +
				"</ns0:checkVat></ns1:Body></SOAP-ENV:Envelope>";
			let isValid: boolean = false;
			var _this = this;
			xmlhttp.onreadystatechange = function () {
				if (xmlhttp.readyState == 4) {
					if (xmlhttp.status == 200) {
						var parser: DOMParser, xmlDoc: any;
						parser = new DOMParser();
						xmlDoc = parser.parseFromString(xmlhttp.responseText, "text/xml");
						if (xmlDoc.getElementsByTagName("valid")[0] != undefined) {
							_this._isValid = xmlDoc.getElementsByTagName("valid")[0].childNodes[0].nodeValue === "true" ? true : false;
							if (xmlDoc.getElementsByTagName("name")[0] != undefined)
								_this._companyName = xmlDoc.getElementsByTagName("name")[0].childNodes[0].nodeValue == null || xmlDoc.getElementsByTagName("name")[0].childNodes[0].nodeValue == undefined ? "" : <string>xmlDoc.getElementsByTagName("name")[0].childNodes[0].nodeValue;
							if (xmlDoc.getElementsByTagName("address")[0] != undefined)
								_this._companyAddress = xmlDoc.getElementsByTagName("address")[0].childNodes[0].nodeValue == null || xmlDoc.getElementsByTagName("address")[0].childNodes[0].nodeValue == undefined ? "" : <string>xmlDoc.getElementsByTagName("address")[0].childNodes[0].nodeValue;
							_this.findAndSetImage(_this._vatNumber.slice(0, 2).toLowerCase());
						}
						else {
							_this._isValid = false;
							_this._context.navigation.openAlertDialog({ text: "No result found for the following VAT Number: " + _this._vatNumber });
							_this.findAndSetImage("warning");
						}
					}
					else {
						_this._context.navigation.openAlertDialog({ text: "Problème avec le service distant: " + xmlhttp.status });
						_this.findAndSetImage(_this._vatNumber.slice(0, 2).toLowerCase());
					}
				}
			}
			// Send the POST request
			xmlhttp.setRequestHeader('Content-Type', 'text/xml');
			xmlhttp.send(soadpRequest);
		}
	}
	/** 
	 * It is called by the framework prior to a control receiving new data. 
	 * @returns an object based on nomenclature defined in manifest, expecting object[s] for property marked as “bound” or “output”
	 */
	public getOutputs(): IOutputs {
		return {
			vatNumberfield: this._vatNumber,
			isVatNumberValid: this._isValid,
			companyName: this._companyName,
			companyAddress: this._companyAddress
		};
	}

	/** 
	 * Called when the control is to be removed from the DOM tree. Controls should use this call for cleanup.
	 * i.e. cancelling any pending remote calls, removing listeners, etc.
	 */
	public destroy(): void {
		// Add code to cleanup control if necessary
	}
	/**
 * Called when a change is detected in the phone number input
 * @param imageName Name of the image to retrieve
 */
	private findAndSetImage(imageName: string) {
		this._context.resources.getResource("img/" + imageName + ".png",
			data => {
				this._vatNumberTypeElement.setAttribute("src", this.generateImageSrcUrl(".png", data));
			},
			() => {
				console.log('Error when downloading ' + imageName + '.png image.');
			});
	}
	/**
 * * This function return a string converted in PascalCase format.
 * @param stringToConvert: String variable to be converted in PascalCase format.
 */
	private ToPascalCase(stringToConvert: string): string {
		return `${stringToConvert}`
			.replace(new RegExp(/[-_]+/, 'g'), ' ')
			.replace(new RegExp(/[^\w\s]/, 'g'), '')
			.replace(
				new RegExp(/\s+(.)(\w+)/, 'g'),
				($1, $2, $3) => `${$2.toUpperCase() + $3.toLowerCase()}`
			)
			.replace(new RegExp(/\s/, 'g'), '')
			.replace(new RegExp(/\w/), s => s.toUpperCase());
	}
	/**
 	* Called when a change is detected in the phone number input
	* @param filetype Name of the image extension
	* @param fileContent Base64 image content
	*/
	private generateImageSrcUrl(fileType: string, fileContent: string): string {
		return "data:image/" + fileType + ";base64," + fileContent;
	}
}