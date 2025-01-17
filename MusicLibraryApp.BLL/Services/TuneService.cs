﻿using MusicLibraryApp.BLL.ModelsDTO;
using MusicLibraryApp.BLL.Services.Interfaces;
using MusicLibraryApp.DAL.Repositories.Interfaces;
using MusicLibraryApp.DAL.Models;
using AutoMapper;
using System.Net.Http.Headers;

namespace MusicLibraryApp.BLL.Services
{
	public class TuneService : IService<TuneDTO>
	{
		public IUnitOfWork UnitOfWork { get; set; }
		public TuneService(IUnitOfWork unitOfWork) => UnitOfWork = unitOfWork;

		public async Task<TuneDTO> GetAsync(int id)
		{
			var tune = await UnitOfWork.Tunes.GetAsync(id);
			return new TuneDTO
			{
				Id = tune.Id,
				Performer = tune.Performer,
				Title = tune.Title,
				FileUrl = tune.FileUrl,
				PosterUrl = tune.PosterUrl,
				IsAuthorized = tune.IsAuthorized,
				IsBlocked = tune.IsBlocked,
				Category = tune.Category,
			};
		}

        public async Task<TuneDTO> GetAsync(string name)
        {
            var tune = await UnitOfWork.Tunes.GetAsync(name);
            return new TuneDTO
            {
                Id = tune.Id,
                Performer = tune.Performer,
                Title = tune.Title,
                FileUrl = tune.FileUrl,
                PosterUrl = tune.PosterUrl,
                IsAuthorized = tune.IsAuthorized,
                IsBlocked = tune.IsBlocked,
                Category = tune.Category,
            };
        }

        public async Task<IEnumerable<TuneDTO>> GetAllAsync()
			=> new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Tune, TuneDTO>()
			.ForMember("Category", o => o.MapFrom(c => c.Category))))
			.Map<IEnumerable<Tune>, IEnumerable<TuneDTO>>(await UnitOfWork.Tunes.GetAllAsync());

		public async Task CreateAsync(TuneDTO modelDTO)
		{
			var tune = new Tune
			{
				Id = modelDTO.Id,
				Performer = modelDTO.Performer,
				Title = modelDTO.Title,
				FileUrl = modelDTO.FileUrl,
				PosterUrl = modelDTO.PosterUrl,
				IsAuthorized = modelDTO.IsAuthorized,
				IsBlocked = modelDTO.IsBlocked,
				Category = modelDTO.Category,
			};
			await UnitOfWork.Tunes.CreateAsync(tune);
			await UnitOfWork.SaveAsync();
		}

		public async Task UpdateAsync(TuneDTO modelDTO)
		{
			var tune = new Tune
			{
				Id = modelDTO.Id,
				Performer = modelDTO.Performer,
				Title = modelDTO.Title,
				FileUrl = modelDTO.FileUrl,
				PosterUrl = modelDTO.PosterUrl,
				IsAuthorized = modelDTO.IsAuthorized,
				IsBlocked = modelDTO.IsBlocked,
				Category = modelDTO.Category,
			};
			UnitOfWork.Tunes.Update(tune);
			await UnitOfWork.SaveAsync();
		}

		public async Task DeleteAsync(int id)
		{
			await UnitOfWork.Tunes.DeleteAsync(id);
			await UnitOfWork.SaveAsync();
		}
	}
}
