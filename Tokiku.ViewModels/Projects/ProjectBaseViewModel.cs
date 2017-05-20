using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokiku.Entity;
using System.Windows;

namespace Tokiku.ViewModels
{
    public class ProjectBaseViewModel : BaseViewModel
    {
        public void CreateModel(Guid ProjectId)
        {

        }

        public ProjectBaseViewModel()
        {

        }

        public static readonly DependencyProperty CodeProperty = DependencyProperty.Register("Code", typeof(string), typeof(ProjectBaseViewModel), new PropertyMetadata(new PropertyChangedCallback(CodeFieldChanged)));

        public static readonly DependencyProperty ProjectSigningDateProperty = DependencyProperty.Register("ProjectSigningDate", typeof(DateTime), typeof(ProjectBaseViewModel), new PropertyMetadata(DateTime.Today, new PropertyChangedCallback(CodeFieldChanged)));

        public static readonly DependencyProperty NameProperty = DependencyProperty.Register("Name", typeof(string), typeof(ProjectBaseViewModel), new PropertyMetadata(new PropertyChangedCallback(CodeFieldChanged)));

        public static readonly DependencyProperty ShortNameProperty = DependencyProperty.Register("ShortName", typeof(string), typeof(ProjectBaseViewModel), new PropertyMetadata(new PropertyChangedCallback(CodeFieldChanged)));

        public static readonly DependencyProperty ClientIdProperty = DependencyProperty.Register("ClientId", typeof(Guid), typeof(ProjectBaseViewModel), new PropertyMetadata(new PropertyChangedCallback(CodeFieldChanged)));

        public static readonly DependencyProperty CreateTimeProperty = DependencyProperty.Register("CreateTime", typeof(DateTime), typeof(ProjectBaseViewModel), new PropertyMetadata(new PropertyChangedCallback(CodeFieldChanged)));

        public static readonly DependencyProperty CreateUserIdProperty = DependencyProperty.Register("CreateUserId", typeof(Guid), typeof(ProjectBaseViewModel), new PropertyMetadata(new PropertyChangedCallback(CodeFieldChanged)));

        public static readonly DependencyProperty SiteAddressProperty = DependencyProperty.Register("SiteAddress", typeof(string), typeof(ProjectBaseViewModel), new PropertyMetadata(new PropertyChangedCallback(CodeFieldChanged)));

        private static void CodeFieldChanged(DependencyObject source, DependencyPropertyChangedEventArgs e)
        {
            if (!e.NewValue.Equals(e.OldValue))
            {
                source.SetValue(IsModifyProperty, true);
                source.SetValue(IsSavedProperty, false);
            }
        }

        public string Code
        {
            get { return (string)GetValue(CodeProperty); }
            set { SetValue(CodeProperty, value); }
        }

        public string Name { get { return (string)GetValue(NameProperty); } set { SetValue(NameProperty, value); } }
        public string ShortName { get { return (string)GetValue(ShortNameProperty); } set { SetValue(ShortNameProperty, value); } }
        public string SiteAddress { get { return (string)GetValue(SiteAddressProperty); } set { SetValue(SiteAddressProperty, value); } }
        public System.Guid ClientId { get { return (Guid)GetValue(ClientIdProperty); } set { SetValue(ClientIdProperty, value); } }
        public System.DateTime CreateTime { get { return (DateTime)GetValue(CreateTimeProperty); } set { SetValue(CreateTimeProperty, value); } }
        public System.Guid CreateUserId { get { return (Guid)GetValue(CreateUserIdProperty); } set { SetValue(CreateUserIdProperty, value); } }
        public DateTime ProjectSigningDate
        {
            get { return (DateTime)GetValue(ProjectSigningDateProperty); }
            set { SetValue(ProjectSigningDateProperty, value); }
        }
        public static readonly DependencyProperty CommentProperty = DependencyProperty.Register("Comment", typeof(string), typeof(ProjectBaseViewModel), new PropertyMetadata(new PropertyChangedCallback(CodeFieldChanged)));
        public string Comment { get { return (string)GetValue(CommentProperty); } set { SetValue(CommentProperty, value); } }
    }
}
