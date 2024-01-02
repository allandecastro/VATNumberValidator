<p align="center">
<a href="https://github.com/allandecastro/VATNumberValidator/blob/master/LICENSE"><img src="https://img.shields.io/badge/license-MIT-blue.svg" alt="License"/></a>
</p>

# VAT Number Validator
 
Here is another Power Apps Component using Power Apps Component framework!

Full story available here: https://www.blog.allandecastro.com/deep-dive-into-power-apps-component-framework-part-4-walkthrough-to-create-your-first-pcf-based-on-a-field/


## Purpose

This component allows you to validate the entry of a VAT Number by checking it with the European Commission and retrieving, depending on the configuration, the address and the name of the company.

Support any entities (OOB and custom) and any BPF (OOB and custom).

## Screenshot

![alt text](https://github.com/allandecastro/VATNumberValidator/blob/master/video.gif?raw=true)

# Installation

You can find the managed and unmanaged solution into ./DeployVATNumberValidator/ folder.

Then you must follow these steps:

* Import the solution into your target environment.

* Open a form where you added a text field.

* Click to managed properties of the field, and add the custom Control "VATNumberValidator"

* You can see that they are severals parameters (with default values), it allows you to configure the component properly. You can refer to the configuration section.

## Configuration

This is the list of parameters that can be set on the control

|Parameter|Description|Required|Example|
|---------|-----------|:----:|:---:|
|**vatNumberfield**|Field containing the VAT Number..|X|SingleLine.Text, SingleLine.TextArea, Multiple|
|**isVatNumberValid**|Boolean field filled-in with the output validity of the VAT Number.||Boolean field|
|**companyName**|Field that will be used to insert the name of the found company.||SingleLine.Text, SingleLine.TextArea, Multiple|
|**companyAddress**|Field that will be used to insert the address of the found company.||SingleLine.Text, SingleLine.TextArea, Multiple|
|**displayDialog**|Specifies whether you want to display error message(s) in the following cases.||null, NotFound, ApiError,Both|


# How to Package a component ?

## Get required tools

To use Microsoft PowerApps CLI, do the following:

* Install Npm (comes with Node.js) or install Node.js (comes with npm). We recommend LTS (Long Term Support) version 10.15.3 LTS as it seems to be most stable.

* Install .NET Framework 4.6.2 Developer Pack.

* If you don’t already have Visual Studio 2017 or later, follow one of the options below:

  * Option 1: Install Visual Studio 2017 or later.
  * Option 2: Install .NET Core 2.2 SDK and then install Visual Studio Code.
* Install Microsoft PowerApps CLI.

Be sure to update your Microsoft PowerApps CLI to the latest version: 
```bash
pac install latest
```
## Build the control

* Clone the repo/ download the zip file.
* Navigate to ./BusinessProcessFlowViewer/ folder.
* Copy the folder path and open it in visual studio code.
* Open the terminal, and run the command the following command to install the project dependencies:
```bash
npm install
```
Then run the command:
```bash
npm run start
```
## Build the solution

* Create a new solution folder (eg. SolutionFolder) and open the Developer command prompt.
* Change the directory to the newly created folder in previous step.
* Init the future solution:
```bash
pac solution init --publisher-name someName --publisher-prefix someSolutionPrefix
``` 
* Add the control to your future solution:
```bash
pac solution add-reference --path provide path of control project folder where the pcf.proj is available
``` 
* Build 1/2:
```bash
msbuild /t:build /restore
``` 
* Build 2/2:
```bash
msbuild or msbuild /p:configuration=Release (for managed solution)
``` 
* You will have the solution file in SolutionFolder/bin/debug and/or release folder!


