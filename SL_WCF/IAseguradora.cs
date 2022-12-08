using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SL_WCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IAseguradora" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IAseguradora
    {
        [OperationContract]
        SL_WCF.Result Add(ML.Aseguradora aseguradora);

        [OperationContract] 
        [ServiceKnownType(typeof(ML.Aseguradora))]
        SL_WCF.Result GetAll();

        [OperationContract]
        SL_WCF.Result Update(ML.Aseguradora aseguradora);

        [OperationContract]
        SL_WCF.Result Delete(int IdAseguradora);

        [OperationContract]
        [ServiceKnownType(typeof(ML.Aseguradora))]
        SL_WCF.Result GetById(int IdAseguradora);
    }
}
