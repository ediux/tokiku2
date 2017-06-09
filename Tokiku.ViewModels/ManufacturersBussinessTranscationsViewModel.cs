using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Tokiku.Entity;

namespace Tokiku.ViewModels
{
    public class ManufacturersBussinessTranscationsViewModel : BaseViewModel
    {

        #region Id
        public Guid Id
        {
            get { return (Guid)GetValue(IdProperty); }
            set { SetValue(IdProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Id.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IdProperty =
            DependencyProperty.Register("Id", typeof(Guid), typeof(ManufacturersBussinessTranscationsViewModel), new PropertyMetadata(Guid.Empty));
        #endregion

        #region Code


        public string Code
        {
            get { return (string)GetValue(CodeProperty); }
            set { SetValue(CodeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Code.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CodeProperty =
            DependencyProperty.Register("Code", typeof(string), typeof(ManufacturersBussinessTranscationsViewModel), new PropertyMetadata(string.Empty));


        #endregion

        #region Name


        public string Name
        {
            get { return (string)GetValue(NameProperty); }
            set { SetValue(NameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Name.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NameProperty =
            DependencyProperty.Register("Name", typeof(string), typeof(ManufacturersBussinessTranscationsViewModel), new PropertyMetadata(string.Empty));


        #endregion

        #region TranscationItemName

        public string TranscationItemName
        {
            get { return (string)GetValue(TranscationItemNameProperty); }
            set { SetValue(TranscationItemNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TranscationItemName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TranscationItemNameProperty =
            DependencyProperty.Register("TranscationItemName", typeof(string), typeof(ManufacturersBussinessTranscationsViewModel), new PropertyMetadata(string.Empty));


        #endregion

        #region ManufacturersId


        public Guid ManufacturersId
        {
            get { return (Guid)GetValue(ManufacturersIdProperty); }
            set { SetValue(ManufacturersIdProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ManufacturersId.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ManufacturersIdProperty =
            DependencyProperty.Register("ManufacturersId", typeof(Guid), typeof(ManufacturersBussinessItemsViewModel), new PropertyMetadata(Guid.Empty,
                new PropertyChangedCallback(DefaultFieldChanged)));


        #endregion

        public override void SetModel(dynamic entity)
        {
            View_ManufacturersBussinessTranscations data = (View_ManufacturersBussinessTranscations)entity;
            BindingFromModel(data, this);
        }
    }
}
