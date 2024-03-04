# Proyecto ArquitecturaG1

Este proyecto es una aplicación que utiliza bases de datos SQL Server junto con una aplicación web, y está diseñado para ejecutarse en Docker.
Se implemento un balanceador de carga con tres imagenes del mismo servidor web a las cuales se les distribuye las petciciones segun el algoritmo especificado

## Ejecución del Proyecto

Para ejecutar este proyecto, asegúrate de tener Docker instalado en tu sistema. A continuación, sigue estos pasos:

1. Clona el proyecto en la rama master https://github.com/DavCoder22/ArquitecturaG1

2. Ubicate en el directorio princial en donde se encuentre el archivo docker-compose.yml y ejecuta el siguiente comando para iniciar los servicios:
   ```bash
   docker-compose up -d
   ```

## Como funciona?
En el archivo  `docker-compose.yml` se encuentran las configuraciones de los contenedores que vamos a utilizar en este proyecto:
son tres imagenes que se encuentran subidas a dockerhub y solo ejecutando dicho comando se ejecutaran las imagenes, las 2 imagenes de 
las bases de datos ya vienen con los datos precargados, para mayor facilidad de uso, ademas con las credenciales de acceso respectivas, la otra imagen es la del servidor que ya se encuentra conectado a dichas bases de datos, se usa tambien una imagen de nginx para el balanceador de carga, se le pasan los argumentos en el mismo docker compose para mayor flexibilidad de uso

## Acceso a la aplicacion

Una vez que los contenedores estén en ejecución, puedes acceder a la aplicación web en tu navegador web a eleccion. La aplicación estará disponible en:

http://localhost:5555

