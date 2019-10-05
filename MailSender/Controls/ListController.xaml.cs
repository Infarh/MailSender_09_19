using System.Collections;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace MailSender.Controls
{
    public partial class ListController
    {
        #region Items property

        public static readonly DependencyProperty ItemsProperty =
           DependencyProperty.Register(
               "Items",
               typeof(IEnumerable),
               typeof(ListController),
               new PropertyMetadata(default(IEnumerable), OnItemsChanged, ItemsCoerceValue),
               ItemsValidate);

        private static bool ItemsValidate(object Value) { return true; }

        private static void OnItemsChanged(DependencyObject D, DependencyPropertyChangedEventArgs E)
        {
        }

        private static object ItemsCoerceValue(DependencyObject D, object Basevalue)
        {
            return Basevalue;
        }

        public IEnumerable Items
        {
            get => (IEnumerable)GetValue(ItemsProperty);
            set => SetValue(ItemsProperty, value);
        } 

        #endregion

        #region SelectedItem : object - Выбранный элемент

        /// <summary>Выбранный элемент</summary>
        public static readonly DependencyProperty SelectedItemProperty =
            DependencyProperty.Register(
                nameof(SelectedItem),
                typeof(object),
                typeof(ListController),
                new PropertyMetadata(default(object)));

        /// <summary>Выбранный элемент</summary>
        //[Category("")]
        [Description("Выбранный элемент")]
        public object SelectedItem { get => (object) GetValue(SelectedItemProperty); set => SetValue(SelectedItemProperty, value); }

        #endregion

        #region PanelName : string - Название панели

        /// <summary>Название панели</summary>
        public static readonly DependencyProperty PanelNameProperty =
            DependencyProperty.Register(
                nameof(PanelName),
                typeof(string),
                typeof(ListController),
                new PropertyMetadata(default(string)));

        /// <summary>Название панели</summary>
        //[Category("")]
        [Description("Название панели")]
        public string PanelName { get => (string) GetValue(PanelNameProperty); set => SetValue(PanelNameProperty, value); }

        #endregion

        #region SelectedItemIndex : int - Индекс выбранного элемента

        /// <summary>Индекс выбранного элемента</summary>
        public static readonly DependencyProperty SelectedItemIndexProperty =
            DependencyProperty.Register(
                nameof(SelectedItemIndex),
                typeof(int),
                typeof(ListController),
                new PropertyMetadata(default(int)));

        /// <summary>Индекс выбранного элемента</summary>
        //[Category("")]
        [Description("Индекс выбранного элемента")]
        public int SelectedItemIndex
        {
            get => (int) GetValue(SelectedItemIndexProperty);
            set => SetValue(SelectedItemIndexProperty, value);
        }

        #endregion

        #region ViewPropertyPath : string - Имя отображаемого свойства

        /// <summary>Имя отображаемого свойства</summary>
        public static readonly DependencyProperty ViewPropertyPathProperty =
            DependencyProperty.Register(
                nameof(ViewPropertyPath),
                typeof(string),
                typeof(ListController),
                new PropertyMetadata(default(string)));

        /// <summary>Имя отображаемого свойства</summary>
        //[Category("")]
        [Description("Имя отображаемого свойства")]
        public string ViewPropertyPath { get => (string) GetValue(ViewPropertyPathProperty); set => SetValue(ViewPropertyPathProperty, value); }

        #endregion

        #region ValuePropertyPath : string - Имя свойства-значения

        /// <summary>Имя свойства-значения</summary>
        public static readonly DependencyProperty ValuePropertyPathProperty =
            DependencyProperty.Register(
                nameof(ValuePropertyPath),
                typeof(string),
                typeof(ListController),
                new PropertyMetadata(default(string)));

        /// <summary>Имя свойства-значения</summary>
        //[Category("")]
        [Description("Имя свойства-значения")]
        public string ValuePropertyPath { get => (string) GetValue(ValuePropertyPathProperty); set => SetValue(ValuePropertyPathProperty, value); }

        #endregion

        #region ItemTemplate : DataTemplate - Шаблон визуализации данных

        /// <summary>Шаблон визуализации данных</summary>
        public static readonly DependencyProperty ItemTemplateProperty =
            DependencyProperty.Register(
                nameof(ItemTemplate),
                typeof(DataTemplate),
                typeof(ListController),
                new PropertyMetadata(default(DataTemplate)));

        /// <summary>Шаблон визуализации данных</summary>
        //[Category("")]
        [Description("Шаблон визуализации данных")]
        public DataTemplate ItemTemplate { get => (DataTemplate) GetValue(ItemTemplateProperty); set => SetValue(ItemTemplateProperty, value); }

        #endregion

        #region Команды

        #region CreateCommand : ICommand - Команда создания нового значения

        /// <summary>Команда создания нового значения</summary>
        public static readonly DependencyProperty CreateCommandProperty =
            DependencyProperty.Register(
                nameof(CreateCommand),
                typeof(ICommand),
                typeof(ListController),
                new PropertyMetadata(default(ICommand)));

        /// <summary>Команда создания нового значения</summary>
        //[Category("")]
        [Description("Команда создания нового значения")]
        public ICommand CreateCommand { get => (ICommand)GetValue(CreateCommandProperty); set => SetValue(CreateCommandProperty, value); }

        #endregion

        #region EditCommand : ICommand - Редактирование элемента

        /// <summary>Редактирование элемента</summary>
        public static readonly DependencyProperty EditCommandProperty =
            DependencyProperty.Register(
                nameof(EditCommand),
                typeof(ICommand),
                typeof(ListController),
                new PropertyMetadata(default(ICommand)));

        /// <summary>Редактирование элемента</summary>
        //[Category("")]
        [Description("Редактирование элемента")]
        public ICommand EditCommand { get => (ICommand)GetValue(EditCommandProperty); set => SetValue(EditCommandProperty, value); }

        #endregion

        #region DeleteCommand : ICommand - Команда удаления элемента

        /// <summary>Команда удаления элемента</summary>
        public static readonly DependencyProperty DeleteCommandProperty =
            DependencyProperty.Register(
                nameof(DeleteCommand),
                typeof(ICommand),
                typeof(ListController),
                new PropertyMetadata(default(ICommand)));

        /// <summary>Команда удаления элемента</summary>
        //[Category("")]
        [Description("Команда удаления элемента")]
        public ICommand DeleteCommand { get => (ICommand)GetValue(DeleteCommandProperty); set => SetValue(DeleteCommandProperty, value); }

        #endregion 
        #endregion

        public ListController() => InitializeComponent();
    }
}
