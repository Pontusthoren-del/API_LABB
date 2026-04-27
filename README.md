Labb 3 – API med Entity Framework
Ett REST API byggt med ASP.NET Core och EF Core. Hanterar användare, deras intressen och tillhörande länkar.
Databasstruktur
Fyra tabeller: User för grundinfo om användaren, Interest för intressen som Climbing eller Gaming, UserInterest som är kopplingstabellen mellan de två, och Link för länkar kopplade till en användare och ett intresse.

Endpoints
GET /api/Users
Hämtar alla användare.
Svar (200): [ { "firstName": "Erik", "lastName": "Larsson", "phoneNumber": "0701111111", "email": "erik@mail.com" } ]

GET /api/Users/{id}/interests
Returnerar alla intressen för en specifik användare.
Svar (200): { "firstName": "Erik", "lastName": "Larsson", "interests": [ "Climbing", "Gaming", "Running" ] }
Svar (404): Användaren finns inte.

GET /api/Users/{id}/links
Hämtar alla länkar kopplade till en användare.
Svar (200): { "firstName": "Erik", "lastName": "Larsson", "interestLinks": [ { "url": "https://climbing.com/", "title": "Climbing" }, { "url": "https://twitch.tv/", "title": "Gaming" } ] }
Svar (404): Användaren finns inte.

POST /api/Users/{userId}/Interests
Kopplar ett intresse till en användare.
Body: { "interestId": 3 }
Svar (200): Intresse kopplat. Svar (404): Användaren eller intresset finns inte. Svar (409): Användaren har redan det intresset.

POST /api/Users/{id}/interests/{interestId}/links
Lägger till en länk kopplad till ett specifikt intresse.
Body: { "url": "https://koket.se", "label": "Köket.se", "interestId": 3 }
Svar (200): Länk tillagd. Svar (404): Användaren eller intresset finns inte.

Övrigt
Allt testat via Swagger och fungerar.
