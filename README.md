# Console App Demo (Bonus)
>An extension of [Console App Demo (Simple)](https://github.com/DoctorStupidMD/console_app_demo_simple), including extra bells and whistles.

## Overview:
This is a simple console application written in C#. The Main Menu prompts a User to either import an XML file or a JSON file, then the
outputted contents of the User's format selection are exported into a new file within the repo.

## User Instructions:
- Ensure that you have both a sample XML file and a sample JSON file downloaded to your preferred location; save the absolute paths for later use.
- Clone this repository to the location of your choosing.
- Launch the `console_app_demo.sln` file with Visual Studio 2022.
- Run by entering F5, clicking the green start button in the top bar, or navigating to 'Debug' in the top menu >> 'Start Debugging'.
- When prompted by the console app's Main Menu, select your desired option and input your file's absolute path.
- If successful, the console will direct you to close the console window and navigate to the repo's `files` directory to view your new file:
`console_app_demo/files/*`.

## Features:
Some additional features of this application that aren't found in the original `console_app_demo_simple` app include:
- Two separate options to convert XML to JSON, and JSON to XML.
- Error handling to detect scenarios such as corrupted XML and JSON data, incorrect extension, incorrect/not a file path, and
lack of user input.
- The ability to prompt the Exit screen by pressing ESC.
- A (very-slightly) nicer user experience.