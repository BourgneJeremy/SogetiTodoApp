# SogetiTodoApp
|| INSTALLATION ||

Pour pouvoir utiliser la solution, il faut au préalable avoir SQL Server d'installé. 
Une fois le repository GitHub mis en place sur votre poste et la solution ouverte, il faut :

- Afficher le "gestionnaire de package" sous visual studio 2022 et entrer les commandes suivantes :
    - Install-Package Microsoft.EntityFrameworkCore.SqlServer
    - Install-Package Microsoft.EntityFrameworkCore.Tools
- Ensuite faites les commandes suivantes :
    - Add-Migration TodoAppDb
    - Update-Database

ATTENTION : modifier la "connectionString" du fichier appsettings.json si vous en avez le besoin.

Après avoir lancé ces instructions, vous pouvez démarrer la solution et vous diriger vers "Mes tâches" pour avoir accès au contenu de l'application web.

|| INSTALLATION DOCKERFILE ||

Le dockerfile ne permet pas de faire fonctionner l'application car j'ai utilisé une base de données locale pour manipuler les données.
Je fais des recherches de mon côté afin de savoir comment je peux résoudre ce problème.
Si vous voulez tout de même lancer le dockerfile, exécutez les commandes suivantes :
- docker build --rm -t productive-dev/cloud-customers:latest .
- docker image ls | grep cloud-customers
- docker run --rm -p 5000:5000 -p 5001:5001 -e ASPNETCORE_HTTP_PORT=https://+:5001 -e ASPNETCORE_URLS=http://+:5000 productive-dev/cloud-customers
