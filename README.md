# LocalRestaurantFinder
A basic site using the Yelp Fusion API to find businesses near a zip code.

## Pre-requisites
* Visual Studio
* [Yelp Fusion API Key](https://www.yelp.com/developers/v3/manage_app)

## Setup & Running
1. You need to store your API Key in Visual Studio's Secret Manager. Navigate to the LocalRestaurantFinder directory and input the following commands.
```
$ dotnet user-secrets init
$ dotnet user-secrets set "APIKey" "YOURAPIKEYHERE"
```
2. Build and run the project. You should be presented with a page that has a title and a text input. 
3. Input a valid zip code into the text input and click the "Search" button. Several restaurants should appear below the search bar.
