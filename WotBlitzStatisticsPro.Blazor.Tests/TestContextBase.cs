﻿using Bunit;
using MediatR;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using NUnit.Framework;
using Radzen;
using WotBlitzStatisticsPro.Blazor.Services;

namespace WotBlitzStatisticsPro.Blazor.Tests
{
    public class TestContextBase: TestContextWrapper
    {
        protected Mock<IMediator> MediatorMock;
        protected Mock<ISearchDialogService> SearchServiceMock;
        protected Mock<INotificationsService> NotificationsServiceMock;
        protected MockNavigationManager NavigationManagerMock;

        [SetUp]
        protected void Init()
        {
            MediatorMock = new();
            SearchServiceMock = new();
            NavigationManagerMock = new();
            NotificationsServiceMock = new ();

            TestContext = new Bunit.TestContext();
            TestContext.Services.AddSingleton(MediatorMock.Object);
            TestContext.Services.AddLocalization();

            TestContext.Services.AddSingleton<DialogService>();
            TestContext.Services.AddSingleton<NotificationService>();
            TestContext.Services.AddSingleton<TooltipService>();
            TestContext.Services.AddSingleton(SearchServiceMock.Object);
            TestContext.Services.AddSingleton(NotificationsServiceMock.Object);


            TestContext.Services.AddSingleton<NavigationManager>(NavigationManagerMock);
        }

        [TearDown]
        public void TearDown() => TestContext?.Dispose();
    }
}