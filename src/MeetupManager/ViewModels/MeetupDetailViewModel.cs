using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotVVM.AutoUI.ViewModel;
using DotVVM.Core.Storage;
using DotVVM.Framework.Controls;
using DotVVM.Framework.Hosting;
using DotVVM.Framework.ViewModel;
using MeetupManager.Core.Model;
using MeetupManager.Core.Selection;
using MeetupManager.Core.Services;

namespace MeetupManager.ViewModels
{
    public class MeetupDetailViewModel : MasterPageViewModel
    {

        private readonly MeetupsService meetupsService;
        private readonly IUploadedFileStorage uploadedFileStorage;
        private readonly ImageStorageService imageStorageService;

        [FromRoute("Id")]
        public int Id { get; set; }

        public MeetupModel Meetup { get; set; }

        public SelectionViewModel<CountrySelection> Countries { get; set; } = new();

        public SelectionViewModel<LocationByCountrySelection, int?> Locations { get; set; }

        public UploadedFilesCollection ImageUpload { get; set; } = new();

        public MeetupDetailViewModel(MeetupsService meetupsService, IUploadedFileStorage uploadedFileStorage, ImageStorageService imageStorageService)
        {
            Locations = new(() => Meetup.CountryId);

            this.meetupsService = meetupsService;
            this.uploadedFileStorage = uploadedFileStorage;
            this.imageStorageService = imageStorageService;
        }

        public override async Task Init()
        {
            await Context.Authorize(roles: new[] { "administrators" });
            await base.Init();
        }

        public override async Task PreRender()
        {
            if (!Context.IsPostBack)
            {
                if (Id == default)
                {
                    Meetup = new MeetupModel()
                    {
                        BeginDate = DateTime.Today.AddDays(1).AddHours(17),
                        EndDate = DateTime.Today.AddDays(1).AddHours(19)
                    };
                }
                else
                {
                    Meetup = await meetupsService.GetMeetupDetail(Id);
                }
            }

            await base.PreRender();
        }

        public async Task Save()
        {
            await meetupsService.SaveMeetup(Meetup);
            Context.RedirectToRoute("MeetupList");
        }

        public async Task ProcessImage()
        {
            if (ImageUpload.Files.Any())
            {
                await using var stream = await uploadedFileStorage.GetFileAsync(ImageUpload.Files[0].FileId);
                Meetup.ImageUrl = await imageStorageService.ResizeAndStoreImage(stream);

                ImageUpload.Files.Clear();
            }
        }

    }
}

