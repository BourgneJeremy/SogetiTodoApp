# SogetiTodoApp

Pour pouvoir utiliser la solution, il faut au préalable avoir SQL Server d'installé. 
Une fois le repository GitHub installé et la solution ouverte, il faut :

- Afficher le "gestionnaire de package" et entrer les commandes suivantes
    . Install-Package Microsoft.EntityFrameworkCore.SqlServer
    . Install-Package Microsoft.EntityFrameworkCore.Tools
- Ensuite faites les commandes suivantes
    . Add-Migration TodoAppDb
    . Update-Database

ATTENTION : modifier la "connectionString" du fichier appsettings.json si besoin.

Après avoir lancé ces instructions, vous pouvez démarrer la solution et vous diriger vers "Mes tâches" pour avoir accès au contenu de l'application web.
