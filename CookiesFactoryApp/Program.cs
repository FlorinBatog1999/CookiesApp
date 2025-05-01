IFilesRepository filesRepository=UserOptionsRepository.USERFILEOPTION==0 ? new FilesRepositoryText() : new FilesRepositoryJSON();
Recipe recipe=new Recipe(filesRepository);

CookiesFactoryApp cookiesFactoryApp=new CookiesFactoryApp(filesRepository, recipe);

cookiesFactoryApp.Run();
 



