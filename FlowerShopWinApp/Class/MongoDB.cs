using System;

using MongoDB.Bson;
using MongoDB.Driver;

internal class MongoDBConnection
{

    #region Global variables

    private String _databaseName;
    private String _username;
    private String _password;

    private Object _mongoClient;
    private Object _mongoDatabase;

    #endregion

    #region Properties

    //public String Name
    //{
    //    get { return _name; }
    //    set { _name = value; }
    //}

    #endregion

    #region Constructors

    public MongoDBConnection(String Database, String UserName, String Password)
    {
        this._databaseName = Database;
        this._username = UserName;
        this._password = Password;

        this.Initialize();
    }

    /// <summary>
    /// Destructor
    /// </summary>
    ~MongoDBConnection() 
    {
        this.Dispose();
    }

    #endregion

    #region Private methods

    private protected void Initialize()
    {
        if(!IsEmptyOrNull(_databaseName) && !IsEmptyOrNull(_username) && !IsEmptyOrNull(_password))
        {
            // Replace the uri string with your MongoDB deployment's connection string.
            var client = new MongoClient($"mongodb+srv://{_username}:{_password}@<cluster-address>/test?w=majority");
            this._mongoClient = client;
            this._mongoDatabase = client.GetDatabase(_databaseName);
        }
    }

    private protected void Dispose()
    {
        GC.SuppressFinalize(this);
    }

    #endregion

    #region Public methods

    public async Boolean AddValues(String CollectionName, Object Values)
    {
        try
        {
            //get mongodb collection
            var collection = this._mongoDatabase.GetCollection<Entity>("CollectionName");
            await collection.InsertOneAsync(Values);
            return true;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex)
        }
    }

    public Boolean UpdateValues(String CollectionName, Object Values)
    {

    }

    public Boolean DeleteValue(String CollectionName, Object Id)
    {

    }

    #endregion

    #region Static methods

    #endregion

}