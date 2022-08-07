# TeshTest

## Controller Details

1. AlbumsController - 
	a.Responsible to retrieve the Album details from 'http://jsonplaceholder.typicode.com/albums'. 
	b.It also retrieves details based on the UserID(Implemented and kept as commented).	

2. PhotosController - 
	a.Responsible to retrieve the Photo details from 'http://jsonplaceholder.typicode.com/photos'. 
	b.It also retrieves details based on the AlbumID(Implemented and kept as commented).

**3. PhotoAlbumController -  Main Controller to get All Album details and their respective Photos and also by UserID.**

## Note: 
As size of the response is too large, swagger is not displaying response for **'/api/PhotoAlbum' and '/api/Photos'** but i have verified the same in debug mode and results looks fine.
 
## TO DO:
1.Logging - Aditionally we have to implement the Logging either in DB or in Flatfile.

2.Unit Test - I have implemented Dependency Injection which supports writing unit test code, as a time constraint i have not implemented.
	
