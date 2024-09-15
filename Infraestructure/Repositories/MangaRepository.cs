using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using mangas.Domain.Entities;

namespace mangas.Infraestructure.Repositories
{
    public class MangaRepository
    {
        private List<Manga> _mangas;
        private string _filepath;

        public MangaRepository(IConfiguration configuration) 
        {
            _filepath = configuration.GetValue<string>("dataBank") ?? string.Empty;
            _mangas = LoadData();
        }

        private string GetCurrentFilePath()
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            var currentFilePath = Path.Combine(currentDirectory, _filepath);
            return currentFilePath;
        }

        private List<Manga> LoadData()
        {
            var currentFilePath = GetCurrentFilePath();
            if (File.Exists(currentFilePath))
            {
                var jsonData = File.ReadAllText(currentFilePath);
                try
                {
                    return JsonSerializer.Deserialize<List<Manga>>(jsonData) ?? new List<Manga>();
                }
                catch (JsonException ex)
                {
                    // Manejar el error de deserialización aquí
                    Console.WriteLine($"Error de deserialización: {ex.Message}");
                    return new List<Manga>();
                }
            }
            return new List<Manga>();
        }

        public IEnumerable<Manga> GetAll()
        {
            return _mangas;
        }

        public Manga GetById(int id)
        {
            return _mangas.FirstOrDefault(manga => manga.Id == id) 
                ?? new Manga
                {
                    Title = string.Empty,
                    Author = string.Empty
                };
        }

        public void Add(Manga manga)
        {
            var currentFilePath = GetCurrentFilePath();
            if (!File.Exists(currentFilePath))
                return;

            _mangas.Add(manga);
            File.WriteAllText(currentFilePath, JsonSerializer.Serialize(_mangas));
        }

        public void Update(Manga updatedManga)
        {
            var currentFilePath = GetCurrentFilePath();
            if (!File.Exists(currentFilePath))
                return;

            var index = _mangas.FindIndex(m => m.Id == updatedManga.Id);
            if (index != -1)
            {
                _mangas[index] = updatedManga;
                File.WriteAllText(currentFilePath, JsonSerializer.Serialize(_mangas));
            }
        }

        public void Delete(int id)
        {
            var currentFilePath = GetCurrentFilePath();
            if (!File.Exists(currentFilePath))
                return;

            _mangas.RemoveAll(m => m.Id == id);
            File.WriteAllText(currentFilePath, JsonSerializer.Serialize(_mangas));
        }
    }
}
