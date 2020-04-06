using Tenanpp.Repository.Models;
using Tenanpp.Repository;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Tenanpp.Services{
    public class InmobiliariaService : BaseService<Inmobiliaria>{

        public InmobiliariaService(TenanppContext context): base(context)
        {
        }

        public override Task<IEnumerable<Inmobiliaria>> GetAll(){
            return _unitOfWork.Inmobiliarias.GetAll();
        }
        public async override Task<Inmobiliaria> Get(long id){
            return await _unitOfWork.Inmobiliarias.Get(id);
        }
        // public async override Task<int> Add(Inmobiliaria entity){
        //     await _unitOfWork.Inmobiliarias.Add(entity);
        //     return await _unitOfWork.CompleteAsync();
        // }
        // public async override Task<int> Delete(Inmobiliaria entity){
        //     await _unitOfWork.Inmobiliarias.Delete(entity);
        //     return _unitOfWork.CompleteAsync();
        // }

        // public async override Task<int> Update(Inmobiliaria dbEntity, Inmobiliaria entityForUpdate){
        //     dbEntity.Nombre = entityForUpdate.Nombre;
        //     dbEntity.Direccion = entityForUpdate.Direccion;
        //     dbEntity.Localidad = entityForUpdate.Localidad;
        //     dbEntity.Telefono = entityForUpdate.Telefono;
        //     dbEntity.Cuit = entityForUpdate.Cuit;
        //     dbEntity.Url = entityForUpdate.Url;
        //     return await _unitOfWork.CompleteAsync();
        // }
    }

}