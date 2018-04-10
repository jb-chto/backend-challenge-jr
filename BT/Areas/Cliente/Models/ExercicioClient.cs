﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using BusinessLibrary.Entity;
using System.Net.Http.Headers;

namespace BT.Areas.Cliente.Models
{
    public class ExercicioClient
    {
        private string Base_URL = "https://bttraining.azurewebsites.net/api/";

        private string Base_API_Module = "Exercicios";

        public IEnumerable<BusinessLibrary.Entity.Exercicio> findAll()
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(Base_URL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync(Base_API_Module).Result;

                if (response.IsSuccessStatusCode)
                    return   response.Content.ReadAsAsync<IEnumerable<BusinessLibrary.Entity.Exercicio>>().Result;
               
                return null;
            }
            catch
            {
                return null;
            }
        }
        public BusinessLibrary.Entity.Exercicio find(int id)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(Base_URL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync(Base_API_Module + "/" + id).Result;

                if (response.IsSuccessStatusCode)
                    return response.Content.ReadAsAsync<BusinessLibrary.Entity.Exercicio>().Result;
                return null;
            }
            catch
            {
                return null;
            }
        }
        public bool Create(BusinessLibrary.Entity.Exercicio exercicio)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(Base_URL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.PostAsJsonAsync(Base_API_Module, exercicio).Result;
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }
        public bool Edit(BusinessLibrary.Entity.Exercicio exercicio)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(Base_URL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.PutAsJsonAsync(Base_API_Module + "/" + exercicio.Exer_id, exercicio).Result;
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }
        public bool Delete(int id)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(Base_URL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.DeleteAsync(Base_API_Module + "/" + id).Result;
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }
    }

}