namespace ElectronicDiary.Domain.Repositories;

public interface IRepository<T, Tkey>
{
    /// <summary>
    /// Get collection of all T-objects
    /// </summary>
    /// <returns>List of T-objects</returns>
    public IEnumerable<T> GetAll();

    /// <summary>
    /// Get T-object wiht such index
    /// </summary>
    /// <param name="id">Indev of needed T-object</param>
    /// <returns></returns>
    public T? Get(Tkey id);

    /// <summary>
    /// Add T-object in collection
    /// </summary>
    /// <param name="obj">Exemplar of T-object which needed to be add in collection</param>
    public void Post(T obj);

    /// <summary>
    /// Replace T-object with such index in collection 
    /// </summary>
    /// <param name="obj">New exemplar of T-object that we are replacing the old one with</param>
    /// <param name="id">Index of replacing T-object</param>
    public bool Put(T obj, Tkey id);

    /// <summary>
    /// Delete T-object with such index from collection
    /// </summary>
    /// <param name="id">Index of deleting T-object</param>
    public bool Delete(Tkey id);
}
