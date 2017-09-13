# LocationParser
Reading Location history files provided by google.

# Installation

*Will be improved in the future*
1. Clone the code from github.
2. Open a command line tool and navigate to the root of the project.
3. Run {dotnet build}.
4. Navigate to the location of the .exe file which was created by the build.

# Getting Started

1. Head over to https://takeout.google.com/settings/takeout.
2. Select the Location history option in JSON format.
3. Choose a preffered Delivery method (easiest is to send download link via email).
4. While waiting for the archive to be ready, get some tea
5. Download the archive, if asked for it, log in with the same google account as the timeline is registered with.
6. Unzip the archive and go to Takout/Location History.
7. Open a command line tool {make sure it's still in the folder where the application was installed}.
8. Run "Locationparser.exe read {path/to/Location History.json}".
