# TP .NET

> [!NOTE]  
> Ma prise de notes est présente dans le fichier : Prise-de-notes.md

## Cloner le repo :

- git clone https://github.com/Marty2R/dotnet-rabatel.git
- cd dotnet-rabatel/projects/mvcTemplate

## Installer dans la racine du projet :

Rendez-vous sur nuget.org et installez :

- Microsoft.EntityFrameworkCore.Design (8.0.0)
- pomelo.ENtityFrameworkCore.MySql (8.0.0)

## Base de données :

- dotnet ef migrations add initialMigration
- dotnet ef database update

## Run le projet :

Dans la racine du projet

- dotnet run

## Info :

> [!WARNING]  
> Le register crée un utilisateur "student" qui permet de créer des "teachers". les routes des pages de d-création sont donc protéger pour que seul un "student" puisse y accéder.
