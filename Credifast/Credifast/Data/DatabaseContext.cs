using Credifast.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace Credifast.Data
{
    public class DatabaseContext
    {
        public SQLiteAsyncConnection Connection { get; set; }
        public DatabaseContext(string path)
        {
            Connection = new SQLiteAsyncConnection(path);

            Connection.CreateTableAsync<ToDoItem>().Wait();
            Connection.CreateTableAsync<Usuario>().Wait();


        }

        public async Task<int> InsertItemAsyn(ToDoItem item)
        {
            return await Connection.InsertAsync(item);
        }

        public async Task<ToDoItem> GetItemByEmailAsync(string email)
        {
            return await Connection.Table<ToDoItem>().FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<int> UpdateItemAsync(ToDoItem item)
        {
            return await Connection.UpdateAsync(item);
        }

        public async Task<int> InsertUsuarioAsync(Usuario usuario)
        {
            return await Connection.InsertAsync(usuario);
        }

        public async Task<int> DeleteItemAsync(Usuario usuario)
        {
            return await Connection.DeleteAsync(usuario);
        }

        public async Task<Usuario> GetUsuarioAsync(int id)
        {
            return await Connection.FindAsync<Usuario>(id);
        }

        public async Task<List<Usuario>> GetItemsAsync()
        {
            return await Connection.Table<Usuario>().ToListAsync();
        }

        public async Task<int> UpdateUsuarioAsync(Usuario usuario)
        {
            return await Connection.UpdateAsync(usuario);
        }




    }
}