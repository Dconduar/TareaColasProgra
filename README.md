# TareaColas
Explicación
Instrucciones para ejecutar el proyecto

1. Clonar el repositorio:
   

2. Abrir el proyecto en Visual Studio:
   Navega a la carpeta del proyecto y abre el archivo QueueApp.sln en Visual Studio.

3. Configurar las credenciales de Azure:
   En el archivo AzureQueueService.cs, busca la siguiente línea:
   string connectionString = "DefaultEndpointsProtocol=https;AccountName=colass;AccountKey=...";
   Reemplaza la cadena de conexión con tus propias credenciales de Azure. Para obtener estas credenciales:
   - Ve al portal de Azure.
   - Navega a Storage Accounts y selecciona tu cuenta de almacenamiento.
   - En Access keys, copia la Key1 y reemplaza la parte correspondiente en el código.

4. Ejecutar el proyecto:
   dotnet run

5. Seleccionar el proveedor de cola:
   El programa te pedirá seleccionar el proveedor de cola (InMemory, Amazon SQS o Azure). Ingresa el número correspondiente a la opción deseada.

Todas las opciones funcionan pero tuve un problema con azure ya que GitHub no me deja subir mis credenciales por temas de seguridad, entonces para poder utilizarlo ingeniero debe utilizar sus propias credenciales.