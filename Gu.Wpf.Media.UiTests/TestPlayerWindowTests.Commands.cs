namespace Gu.Wpf.Media.UiTests
{
    using System;
    using System.Threading;

    using Gu.Wpf.Media.UiTests.Helpers;

    using NUnit.Framework;

    using TestStack.White.UIItems;

    public partial class TestPlayerWindowTests
    {
        public Button PlayButton => this.Window.Get<Button>("Play");

        public Button PauseButton => this.Window.Get<Button>("Pause");

        public Button StopButton => this.Window.Get<Button>("Stop");

        public Button PlayPauseButton => this.Window.Get<Button>("TogglePlayPause");

        public Button BoundPlayPauseButton => this.Window.Get<Button>("BoundPlayPause");

        public Button RewindButton => this.Window.Get<Button>("Rewind");

        [Test]
        public void ClickPlayThenClickPause()
        {
            this.SetValue(MediaElementWrapper.SourceProperty, Info.CoffeeClipFileName());
            var position = this.GetValue(MediaElementWrapper.PositionProperty);
            Assert.AreEqual(true, this.PlayButton.Enabled);
            Assert.AreEqual(false, this.PauseButton.Enabled);
            this.PlayButton.Click();
            Assert.AreEqual(false, this.PlayButton.Enabled);
            Assert.AreEqual(true, this.PauseButton.Enabled);
            this.AreEqual("True", false, MediaElementWrapper.IsPlayingProperty);
            this.AreEqual("Play", false, MediaElementWrapper.StateProperty);

            Thread.Sleep(TimeSpan.FromSeconds(0.2));

            this.PauseButton.Click();
            Assert.AreEqual(true, this.PlayButton.Enabled);
            Assert.AreEqual(false, this.PauseButton.Enabled);
            this.AreEqual("False", false, MediaElementWrapper.IsPlayingProperty);
            this.AreEqual("Pause", false, MediaElementWrapper.StateProperty);
            Assert.AreNotEqual(position, this.GetValue(MediaElementWrapper.PositionProperty));
        }

        [Test]
        public void TogglePlayPause()
        {
            this.SetValue(MediaElementWrapper.SourceProperty, Info.CoffeeClipFileName());
            var position = this.GetValue(MediaElementWrapper.PositionProperty);
            Assert.AreEqual(true, this.PlayButton.Enabled);
            Assert.AreEqual(false, this.PauseButton.Enabled);
            this.PlayPauseButton.Click();
            Assert.AreEqual(false, this.PlayButton.Enabled);
            Assert.AreEqual(true, this.PauseButton.Enabled);
            this.AreEqual("True", false, MediaElementWrapper.IsPlayingProperty);
            this.AreEqual("Play", false, MediaElementWrapper.StateProperty);

            Thread.Sleep(TimeSpan.FromSeconds(0.2));

            this.PlayPauseButton.Click();
            Assert.AreEqual(true, this.PlayButton.Enabled);
            Assert.AreEqual(false, this.PauseButton.Enabled);
            this.AreEqual("False", false, MediaElementWrapper.IsPlayingProperty);
            this.AreEqual("Pause", false, MediaElementWrapper.StateProperty);
            Assert.AreNotEqual(position, this.GetValue(MediaElementWrapper.PositionProperty));
        }

        [Test]
        public void ToggleBoundPlayPause()
        {
            this.SetValue(MediaElementWrapper.SourceProperty, Info.CoffeeClipFileName());
            var position = this.GetValue(MediaElementWrapper.PositionProperty);
            Assert.AreEqual(true, this.PlayButton.Enabled);
            Assert.AreEqual(false, this.PauseButton.Enabled);
            this.BoundPlayPauseButton.Click();
            Assert.AreEqual(false, this.PlayButton.Enabled);
            Assert.AreEqual(true, this.PauseButton.Enabled);
            this.AreEqual("True", false, MediaElementWrapper.IsPlayingProperty);
            this.AreEqual("Play", false, MediaElementWrapper.StateProperty);

            Thread.Sleep(TimeSpan.FromSeconds(0.2));

            this.BoundPlayPauseButton.Click();
            Assert.AreEqual(true, this.PlayButton.Enabled);
            Assert.AreEqual(false, this.PauseButton.Enabled);
            this.AreEqual("False", false, MediaElementWrapper.IsPlayingProperty);
            this.AreEqual("Pause", false, MediaElementWrapper.StateProperty);
            Assert.AreNotEqual(position, this.GetValue(MediaElementWrapper.PositionProperty));
        }


        [Test]
        public void ClickPlayThenClickStop()
        {
            this.SetValue(MediaElementWrapper.SourceProperty, Info.CoffeeClipFileName());
            var position = this.GetValue(MediaElementWrapper.PositionProperty);
            Assert.AreEqual(true, this.PlayButton.Enabled);
            Assert.AreEqual(false, this.PauseButton.Enabled);
            this.PlayButton.Click();
            Assert.AreEqual(false, this.PlayButton.Enabled);
            Assert.AreEqual(true, this.PauseButton.Enabled);
            this.AreEqual("True", false, MediaElementWrapper.IsPlayingProperty);
            this.AreEqual("Play", false, MediaElementWrapper.StateProperty);

            Thread.Sleep(TimeSpan.FromSeconds(0.2));

            this.StopButton.Click();
            Assert.AreEqual(true, this.PlayButton.Enabled);
            Assert.AreEqual(false, this.PauseButton.Enabled);
            this.AreEqual("False", false, MediaElementWrapper.IsPlayingProperty);
            this.AreEqual("Stop", false, MediaElementWrapper.StateProperty);
            Assert.AreNotEqual(position, this.GetValue(MediaElementWrapper.PositionProperty));
        }

        [Test]
        public void ClickPlayThenClickPauseThenRewind()
        {
            this.SetValue(MediaElementWrapper.SourceProperty, Info.CoffeeClipFileName());
            var position = this.GetValue(MediaElementWrapper.PositionProperty);
            Assert.AreEqual(true, this.PlayButton.Enabled);
            Assert.AreEqual(false, this.PauseButton.Enabled);
            this.PlayButton.Click();
            Assert.AreEqual(false, this.PlayButton.Enabled);
            Assert.AreEqual(true, this.PauseButton.Enabled);
            this.AreEqual("True", false, MediaElementWrapper.IsPlayingProperty);
            this.AreEqual("Play", false, MediaElementWrapper.StateProperty);

            Thread.Sleep(TimeSpan.FromSeconds(0.2));

            this.PauseButton.Click();
            Assert.AreEqual(true, this.PlayButton.Enabled);
            Assert.AreEqual(false, this.PauseButton.Enabled);
            this.AreEqual("False", false, MediaElementWrapper.IsPlayingProperty);
            this.AreEqual("Pause", false, MediaElementWrapper.StateProperty);
            Assert.AreNotEqual(position, this.GetValue(MediaElementWrapper.PositionProperty));

            Assert.AreEqual(true, this.RewindButton.Enabled);
            this.RewindButton.Click();
            this.AreEqual("00:00:00", false, MediaElementWrapper.PositionProperty);
        }
    }
}