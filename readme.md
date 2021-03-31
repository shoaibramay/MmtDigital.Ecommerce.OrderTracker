Some Json markup was invalid. I assumed its by mistake so ignored it and used correct markup to create my view models.
Docker support is added for easy deployment.
Testing from end user prospective is done to make sure API works as per requirements.
Wished to spend some time on unit testing but did run out of time
Wished to spend some time to take a second look to clean / refactor the code.
API currently has no security, should be secured using API key before production
Some design changes may be required before going into production. i.e.  Passing User / Customer Id to the API is unnecessary and just adding confusion. Email is enough to pass as customer data is retrieved using email only.
