# walmart-search

Para usar mongo se subió el archivo a un cluster en MongoDB Atlas

Comandos para correr localmente:

- docker-compose build
- docker-compose up -d

Para los tests se usó un cluster en MongoDB Atlas con la información de tests.json.

Para correr los tests se recomienda utilizar JetBrains Rider o Visual Studio, ya que no pude lograr que el sistema los encontrara con docker. Por otro lado, si se cuenta con ASP.NET CORE 3.1

- dotnet test

Algunas de las versiones del problema, aunque no me dieron resultado son las siguientes:
- https://github.com/microsoft/vstest/issues/2079
- https://github.com/microsoft/vstest/issues/578
- https://developercommunity.visualstudio.com/content/problem/294428/make-sure-that-test-discoverer-executors-are-regis-1.html