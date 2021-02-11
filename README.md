# hexagonal-dotnet

Hexagonal Architecture by example - a hands-on introduction

## architecture

![alt text](./architecture.png "Architecture")

### 2 applications

* [CLI](./Ideator.CLI)
* [WebApi](./Ideator.API) 

### 1 hexagon

* [Domain](./Ideator.Domain)

### and some adapters

* [DB Integration](./Ideator.ArticleDb)
* [External Service](./Ideator.AuthorService)
* [Message Broker](./Ideator.MessageBroker)
* [Notifications](./Ideator.Notifications)
* [Social Media](./Ideator.SocialMedia)

## inspired by

* https://blog.allegro.tech/2020/05/hexagonal-architecture-by-example.html
* https://github.com/ivanpaulovich/clean-architecture-manga
* https://enterprisecraftsmanship.com/posts/value-object-better-implementation/
* https://www.romanx.co.uk/posts/playing-with-my-record-collection
