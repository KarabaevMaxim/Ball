using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Common.Application;
using Newtonsoft.Json;
using UnityEngine;

namespace Application.Storage
{
  /// <summary>
  /// Реализация хранилище в виде json файла.
  /// </summary>
  /// <typeparam name="TEntity">Тип сущности.</typeparam>
  public class JsonStorage<TEntity> : IStorage<TEntity> where TEntity : IEntity
  {
    private readonly string _fullFileName;
    
    public void Save(TEntity entity)
    {
      var all = ReadAllInternal();
      var old = all.FirstOrDefault(e => e.Id == entity.Id);

      if (old != null)
        all.Remove(old);

      all.Add(entity);
      var serialized = Serialize(all);
      // не проверяем на null, чтобы приложение упало, если возникнет такая ситуация
      WriteToFile(serialized);
    }

    public Task SaveAsync(TEntity entity)
    {
      return Task.Run(() => Save(entity));
    }

    public TEntity Read(Guid id)
    {
      return ReadAll().FirstOrDefault(e => e.Id == id);
    }

    public async Task<TEntity> ReadAsync(Guid id)
    {
      return (await ReadAllAsync()).FirstOrDefault(e => e.Id == id);
    }

    public IReadOnlyList<TEntity> ReadAll()
    {
      return ReadAllInternal();
    }

    public Task<IReadOnlyList<TEntity>> ReadAllAsync()
    {
      return Task.Run(ReadAll);
    }
    
    public void InitializeDefaultData()
    {
      var json = Serialize(new List<TEntity>());
      WriteToFile(json);
    }

    private List<TEntity> ReadAllInternal()
    {
      return DeserializeMany(ReadFromFile());
    }
    
    /// <summary>
    /// Записывает данные в файл. Если файл не найден, то он будет создан.
    /// </summary>
    private void WriteToFile(string text)
    {
      try
      {
        File.WriteAllText(_fullFileName, text);
      }
      catch (IOException ex)
      {
        Debug.LogError($"Не удалось сохранить данные в файл {_fullFileName}. {ex}");
      }
    }
    
    /// <summary>
    /// Читает данные из файла. Если файл не найден, то создает его и инициализирует его данными по-умолчанию.
    /// </summary>
    private string ReadFromFile()
    {
      try
      {
        return File.ReadAllText(_fullFileName);
      }
      catch (FileNotFoundException)
      {
        InitializeDefaultData();
        return ReadFromFile();
      }
      catch (IOException ex)
      {
        Debug.LogError($"Не удалось прочитать данные из файла {_fullFileName}. {ex}");
        throw;
      }
    }

    private string Serialize(object obj)
    {
      try
      {
        return JsonConvert.SerializeObject(obj);
      }
      catch(JsonSerializationException ex)
      {
        Debug.LogError($"Не удалось сериализовать данные сохранения в json. {ex}");
        return null;
      }
    }
    
    private TEntity Deserialize(string json)
    {
      try
      {
        return JsonConvert.DeserializeObject<TEntity>(json);
      }
      catch (JsonException ex)
      {
        Debug.LogError($"Не удалось десериализовать данные сохранения из json. {ex}");
        return default;
      }
    }
    
    private List<TEntity> DeserializeMany(string json)
    {
      try
      {
        return JsonConvert.DeserializeObject<List<TEntity>>(json);
      }
      catch (JsonException ex)
      {
        Debug.LogError($"Не удалось десериализовать данные сохранения из json. {ex}");
        return default;
      }
    }
    
    public JsonStorage()
    {
      // единое хранилище сдлеать не успеваю, поэтому для каждой гипотетической сущности будет по файлу
      _fullFileName = Path.Combine(UnityEngine.Application.persistentDataPath, $"storage_{nameof(TEntity)}.json");
    }
  }
}