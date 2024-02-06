# Proyecto ArquitecturaG1

Este proyecto es una aplicación que utiliza bases de datos SQL Server junto con una aplicación web, y está diseñado para ejecutarse en Docker.

## Ejecución del Proyecto

Para ejecutar este proyecto, asegúrate de tener Docker instalado en tu sistema. A continuación, sigue estos pasos:

1. Clona este repositorio en tu máquina local:

   ```bash
   git clone https://github.com/tu_usuario/arquitectura-g1.git

2. Cambia al directorio del proyecto:   
    ```bash
    cd arquitectura-g1

3. Ejecuta el siguiente comando para iniciar los servicios:
    ```bash
    docker-compose up -d

## Acceso a la aplicacion
Una vez que los contenedores estén en ejecución, puedes acceder a la aplicación web en tu navegador web favorito. La aplicación estará disponible en:

http://localhost:8080

## Imagen docker de la aplicacion
También hemos creado una imagen Docker de esta aplicación y la hemos subido a Docker Hub. Puedes encontrar la imagen en:

leandroexp/imgarquitectura

no es necesario descargarla manualmente ya que se decargara al ejecura el archivo   "docker-compose.yml"
