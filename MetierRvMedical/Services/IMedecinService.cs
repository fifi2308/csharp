using MetierRvMedical.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;

namespace MetierRvMedical.Services
{
    [ServiceContract]
    public interface IMedecinService
    {
        [OperationContract]
        List<Medecin> GetAllMedecins();

        [OperationContract]
        Medecin GetMedecinById(string id);

        [OperationContract]
        void AddMedecin(Medecin medecin);

        [OperationContract]
        void UpdateMedecin(Medecin medecin);

        [OperationContract]
        void DeleteMedecin(string id);
    }
}