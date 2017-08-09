using Microsoft.WindowsAzure.MobileServices;
using RightPeople.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RightPeople.Services
{
    public class AzureDataService
    { 

    // public async Task SyncUsuario()
    //{

    //    var client = new MobileServiceClient("https://rightpeople1.azurewebsites.net");

    //    IMobileServiceTable<Usuarios> UsuarioTable = client.GetTable<Usuarios>();

    //    try
    //    {

    //        //List<Usuarios> items =  await UsuarioTable.Where(c => c.)
    //        //.ToListAsync();
    //    }
    //    catch (Exception ex)
    //    {
    //        Debug.WriteLine("Upss... Algo ha ocurrido, favor de intentarlo de nuevo: " + ex);
    //    }

    //}

    //public async Task<IEnumerable<Usuarios>> GetUsuarios()
    //{
    //    //Initialize & Sync

    //    var client = new MobileServiceClient("https://coepUsuario.azurewebsites.net");

    //    IMobileServiceTable<Usuarios> UsuarioTable = client.GetTable<Usuarios>();

    //    //await Initialize();
    //    await SyncUsuario();

    //    return await UsuarioTable.OrderBy(c => c.DateUtc).ToEnumerableAsync(); ;

    //}

    //public async Task UpdateUsuario(Usuarios item)
    //{

    //    var client = new MobileServiceClient("https://coepUsuario.azurewebsites.net");

    //    MobileServicePreconditionFailedException<Usuarios> preconditionFailure = null;

    //    try
    //    {
    //        var onlineDairyTable = client.GetTable<Usuarios>();

    //        await onlineDairyTable.UpdateAsync(item);

    //    }
    //    catch (MobileServicePreconditionFailedException<Usuarios> ex)
    //    {
    //        preconditionFailure = ex;

    //    }
    //    // Oh no - a conflict!
    //    if (preconditionFailure != null)
    //    {
    //        // Note that the "Item" property is a copy of the dairy row from the server that's trying to be updated
    //        await ResolveConflict(item, preconditionFailure.Item);
    //    }
    //}

    //private async Task ResolveConflict(Usuarios localVersionOfDairy, Usuarios azuresVersionOfDairy)
    //{
    //    // Here we're just deciding to use our app's version of the dairy by 
    //    // giving it the same _version column value of what is in the server - (last in wins)
    //    localVersionOfDairy.AzureVersion = azuresVersionOfDairy.AzureVersion;

    //    await UpdateUsuario(localVersionOfDairy);
    //}



    //public async Task<Usuarios> AddUsuario()
    //{


    //    var client = new MobileServiceClient("https://coepUsuario.azurewebsites.net");

    //    IMobileServiceTable<Usuarios> UsuarioTable = client.GetTable<Usuarios>();


    //    var usuario = new Usuarios
    //    {

    //    };

    //    await UsuarioTable.InsertAsync(usuario);

    //    await SyncUsuario();
 
    //    return usuario;
    //}
}
}