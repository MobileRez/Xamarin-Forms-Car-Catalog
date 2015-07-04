# Xamarin-Forms-Car-Catalog
A demo Xamarin.Forms app for a car catalog that shows off, Custom Renders, SQLite, and more

## About this app
This app was created to show how Xamarin.Forms & Custom Renders work as well as showcasing how dynamic a Xamarin.Forms app can be made (making less actual play store updates needed when changes happen).

## SQLite DB
#### Makes Table
|   Column    |  Format  |
|:-----------:|:--------:| 
| MakeId (pk) |    int   |
| MakeName | varchar(255) |
| LastUpdateDate | DateTime |

#### Models Table
|   Column    |  Format  |
|:-----------:|:--------:| 
| ModelId (pk) |    int   |
| ModelName | varchar(255) |
| MakeId | int |
| LastUpdateDate | DateTime|

#### Years Table
|   Column    |  Format  |
|:-----------:|:--------:| 
| YearId (pk) |    int   |
| YearName | varchar(255) |
| LastUpdateDate | DateTime |

## Code Documentation


## TO DO LIST
- [ ] Add in Custom rendered navigation for modified navigation behavior
  - [ ] Make behavior of navigation the same across all platforms
  - [ ] Account for changes in navigation when on a phone vers tablet (really adust for phablet support)
- [ ] Create and populate sqlite table on app for holding navigation iformation.
  - [ ] Hook up Navigation page to sqlite table and generate navigation items from links on platform.
- [ ] Implment Pintch and zoom controls with a Carousel Page
- [ ] Create UI testing
- [ ] Create Documentation 
- [ ] Intigrate App with xamarin forms in a way that people can load up the own insights id, and if not, the app will not crash if it is not implmented
- [ ] Expand this document to include explination of the code/samples
- [ ] Other ideas /features as they come.


# Credits to those whos code or experence helped me put this together.
* [James Montemagno](https://github.com/jamesmontemagno) & [Scott Hanselman](https://github.com/shanselman) for providing the demo app to learn about how to do a good MVVM envrioment [Hanselman.Forms: Hanselman Everywhere](https://github.com/jamesmontemagno/Hanselman.Forms)
* Jesse Dietrichson
* Chris van Wyk