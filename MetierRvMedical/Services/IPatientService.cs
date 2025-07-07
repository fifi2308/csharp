using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;
using MetierRvMedical.Model;

namespace MetierRvMedical.Services
{
    [ServiceContract]
    public interface IPatientService
    {
        [OperationContract]
        List<Patient> GetAllPatients();

        [OperationContract]
        Patient GetPatientById(int id);

        [OperationContract]
        void AddPatient(Patient patient);

        [OperationContract]
        void UpdatePatient(Patient patient);

        [OperationContract]
        void DeletePatient(int id);
    }

}