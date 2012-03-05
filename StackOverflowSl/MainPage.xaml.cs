using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace StackOverflowSl
{
    public partial class MainPage : UserControl
    {
        UIElement questionsControl = null;

        public MainPage()
        {
            InitializeComponent();
            questionsControl = (UIElement) this.ContentControl.Content;
        }

        private void Question_Click(object sender, RoutedEventArgs e)
        {
            Question q = (sender as HyperlinkButton).DataContext as Question;
            if (q.Content == null) q.Content = (UIElement)System.Activator.CreateInstance(q.Type);
            Control answersControl = new AnswerPage() { 
                DataContext=q, 
                VerticalAlignment= System.Windows.VerticalAlignment.Stretch, 
                HorizontalAlignment = HorizontalAlignment.Stretch };
            SwapContent(answersControl);
        }

        private void SwapContent(Control answersControl)
        {
            ContentControl.Content = answersControl;
        }

        internal void ShowQuestions()
        {
            ContentControl.Content = this.questionsControl;
        }

        public string Title { get { return "Silverlight StackOverflow Questions"; } }
    }

    public class Question
    {
        public string QuestionTitle { get; set; }
        public string Url { get; set; }
        public Type Type { get; set; }
        public object Content { get; set; }
    }

    public class QuestionCollection : List<Question> { }
}
