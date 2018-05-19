# RegularPolygon
Recruitment task for Vistex Internship program 2018. 

## Description
Program allows user to calculate area and vertices coordinates of regular polygon with specified side length and number of sides.
Result can be displayed on console or saved in file.

## User Manual
Program needs to be provided with 3 parameters in following order:
  1. **Number of vertices**  
      Has to be integer greater than 2.
  2. **Side length**   
     Has to be floating point number greater than 0.  
     Accepted format is: A.B where A is integer part and B is fractional part 
  3. **Output mode**   
     Single character specifying what application should do with generated polygon.   
     Accepted characters are:     
     * **'d'** or **'D'** - application will display result on console    
     * **'f'**  or **'F'** - application will save result to file.     
     Generated file will be named "SavedPolygonDescription.txt" and will be located in application working directory.   
      
If any parameter will be invalid, error description will be shown on console.
At the end program will prompt the user to click any key in order to finish program process.

        
## Examples

* Display description of pentagon with side length of 4.23     
`polygon.exe 5 4.23 d`    
* Save to file description of hexagon with side length of 2     
`polygon.exe 6 2 f`   
