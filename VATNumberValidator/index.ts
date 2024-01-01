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
	private _displayDialog: string;

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
		this._context = context;
		this._container = container;
		this._notifyOutputChanged = notifyOutputChanged;
		this._vatNumberChanged = this.vatNumberChanged.bind(this);

		this._vatNumber = this._context.parameters.vatNumberfield == null || this._context.parameters.vatNumberfield.raw == null ? "" : this._context.parameters.vatNumberfield.raw.trim();
		this._companyName = this._context.parameters.companyName == null || this._context.parameters.companyName.raw == null ? "" : this._context.parameters.companyName.raw;
		this._companyAddress = this._context.parameters.companyAddress == null || this._context.parameters.companyAddress.raw == null ? "" : this._context.parameters.companyAddress.raw;
		this._displayDialog = this._context.parameters.displayDialog == null || this._context.parameters.displayDialog.raw == null ? "" : this._context.parameters.displayDialog.raw;

		this._container = document.createElement("div");
		container.appendChild(this._container);
		this._vatNumberElement = document.createElement("input");
		this._vatNumberElement.setAttribute("type", "text");
		if (this._vatNumber.length > 0)
			this._vatNumberElement.setAttribute("title", this._vatNumber);
		else
			this._vatNumberElement.setAttribute("title", "Select to enter data");
		this._vatNumberElement.setAttribute("class", "pcfvatinputcontrol");
		this._vatNumberElement.addEventListener("change", this._vatNumberChanged);
		this._vatNumberTypeElement = document.createElement("img");
		this._vatNumberTypeElement.setAttribute("class", "pcfvatimagecontrol");
		this._vatNumberTypeElement.setAttribute("height", "24px");
		this._container.appendChild(this._vatNumberElement);
		this._container.appendChild(this._vatNumberTypeElement);
		this.SecurityEnablement(this._vatNumberElement);
	}
	/**
	* Called when a change is detected in the phone number input.
	*/
	private async vatNumberChanged(): Promise<void> {
		this._vatNumberElement.value = this._vatNumberElement.value.trim().replace(" ", "").toUpperCase();
		await this.CheckVatNumber();
		if (this._vatNumber != this._vatNumberElement.value) {
			this._vatNumber = this._vatNumberElement.value;
			this._vatNumberElement.setAttribute("title", this._vatNumber);
			this._notifyOutputChanged();
			
		}
	}

	/**
	 * Called when any value in the property bag has changed. This includes field values, data-sets, global values such as container height and width, offline status, control metadata values such as label, visible, etc.
	 * @param context The entire property bag available to control via Context Object; It contains values as set up by the customizer mapped to names defined in the manifest, as well as utility functions
	 */
	public updateView(context: ComponentFramework.Context<IInputs>): void {
		let visible = this._context.mode.isVisible;
		if (visible) {
			this._vatNumber = this._context.parameters.vatNumberfield == null || this._context.parameters.vatNumberfield.raw == null ? "" : this._context.parameters.vatNumberfield.raw.trim();
			if (this._vatNumber != null && this._vatNumber.length > 0 && this._vatNumber != this._vatNumberElement.value) {
				this._vatNumberElement.value = this._vatNumber;
				this.CheckVatNumber();
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
	private async CheckVatNumber(): Promise<void> {
		//ATU65450549
		this.findAndSetImage("loading","gif");
		if (this._vatNumberElement.value.length > 0) {
			try {
				var request = new ValidateVATRequest(this._vatNumberElement.value);
				var response = await (this._context.webAPI as any).execute(request);
				var result = await response.json();
				if (result.Valid == true) {
					this._isValid = true;
					if (result.Name != undefined)
						this._companyName = result.Name;
					if (result.Address != undefined)
						this._companyAddress = result.Address;
					this.findAndSetImage(this._vatNumberElement.value.slice(0, 2).toLowerCase(),"png");
				}
				else {
					this._isValid = false;
					if (this._displayDialog === "Both" || this._displayDialog === "NotFound")
						this._context.navigation.openAlertDialog({ text: "No result found for the following VAT Number: " + this._vatNumberElement.value });
					this.findAndSetImage("warning","png");
				}
			}
			catch (ex) {
				if (this._displayDialog === "Both" || this._displayDialog === "ApiError")
					this._context.navigation.openAlertDialog({ text: "Error from Service: " + ex });
			}

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
	private findAndSetImage(imageName: string,imageExtension:string) {
		this._context.resources.getResource("img/" + imageName + "."+imageExtension,
			data => {
				this._vatNumberTypeElement.setAttribute("src", this.generateImageSrcUrl("."+imageExtension, data));
			},
			() => {
				console.log('Error when downloading ' + imageName + '.'+imageExtension+' image.');
			});
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

class ValidateVATRequest {
    private readonly VAT: string;

    constructor (vat: string){
        this.VAT = vat;
    }

    getMetadata = function () {
        let metadata = {
            boundParameter: null as unknown as string,
            parameterTypes: {
                "VAT": {
                    "typeName": "Edm.String",
                    "structuralProperty": 1,
                },
            },
            operationName: "mwo_ValidateVAT",
            operationType: 0,
        };
        return metadata;
    };
}
