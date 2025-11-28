#!/bin/bash
# Script de despliegue automático para FrontendBlazorApi

echo "🚀 Iniciando despliegue del Frontend Blazor..."

# Ruta de msdeploy
MSDEPLOY="/c/Program Files/IIS/Microsoft Web Deploy V3/msdeploy.exe"

# Datos del servidor
SITE_NAME="site44850"
PUBLISH_URL="site44850.siteasp.net"
USERNAME="site44850"
PASSWORD="Wy9%2H@aBt7?"
LOCAL_PATH="C:\2025\PROYECTOS_FRONT\FrontendBlazorApi\publicado"

# Ejecutar despliegue
"$MSDEPLOY" -verb:sync \
  -source:contentPath="$LOCAL_PATH" \
  -dest:contentPath="$SITE_NAME",computerName="https://$PUBLISH_URL:8172/MsDeploy.axd?site=$SITE_NAME",userName="$USERNAME",password="$PASSWORD",authType="Basic" \
  -allowUntrusted \
  -enableRule:AppOffline

if [ $? -eq 0 ]; then
    echo "✅ Despliegue completado exitosamente"
    echo "🌐 Tu aplicación está disponible en la URL configurada"
else
    echo "❌ Error en el despliegue"
    exit 1
fi
