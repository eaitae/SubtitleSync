# Subtitle Sync
Subtitle Sync is a desktop application that shifts a SRT file to the given timespan. In other words, it fixes an out of sync subtitle. It is a WPF application, .Net Framework. 

![SubtitleSync](https://media.discordapp.net/attachments/941386143168098406/951508313177227264/Untitlsdfsdfed.png)

## 

◽ The MVVM 

It is the natural pattern to XAML application, and as we know, WPF uses XAML, so the best choice is to use MVVM in our applications. It makes our app easy to maintain, to test and reuse. MVVM stands for Model, View and View Model and those are the categories we gonna use to organize our project. Here I've decided to not use the Model, I believe it isn't necessary in this case. 

Also, it is important to remeber to always use a separate folder for images and medias. In this way, our code is gonna be more organized. 

![MVVMexample](https://media.discordapp.net/attachments/941386143168098406/951577718191980564/Untitlesdasdd.png)

## 

◽ The SHIFTER 

The logic I used for the shifter was simple. I had one problem and created the solution: I'm receiving a subtitle out of sync, I need to fix it and return it synced. For that I followed thoses steps: 

1. Read the origin file. For that I used a stream reader. 
2. Indentify the line I was supposed to change. I choose to do that by using a regex. 
3. Do the actual shift by adding the giving time span. 
4. Write the corrected subtitle and return it. Keeping the use of stream files, here I used a stream writer. 

##  

◽ Thinking about UX  

- When we think about WPF, we know that INotifyPropertyChanged and ICommand are very important. By using them I was able to block the buttons, being sure that the user would just be capable of executing or previewing the file if the necessary objects were set. 

Here is when the buttons are blocked

![Buttons1](https://media.discordapp.net/attachments/941386143168098406/951585075022139472/Untitlasdasdesdasdd.png)

And when it's possible to execute and preview the file 

![Buttons2](https://media.discordapp.net/attachments/941386143168098406/951585074820833340/Untitlasdasdessdasdd.png)

- In case the user has more than one monitor, I set the Preview Window to always open in the same monitor the main window is being displayed. I could do that by using the code behind to set the Preview Window owner. Like this: 

'Owner = Application.Current.MainWindow;' 

- When choosing the destination path, the user has the choice to create a new file or to use one that already exists. It is possible by using the SaveFileDialog instead of the OpenFileDialog (which one I've used to select the origin path). 

- Finally, to be sure the user wouldn't change the origin or destination path by mistake, I set the property IsReadOnly to true in every textbox that I was using as a path display. 

- Ah! Before I forget, I also formated the timespan placeholder so the user can be aware of the valid format. 

##  

◽ Some DETAILS 

I've set an icon to represent the whole application and a second one only for the Preview Window so it can be differentiated. Talking about the Preview Window, it has the scrollbar visible. It helps case the user doesn't have a mouse scroll button.  

![Windows](https://media.discordapp.net/attachments/941386143168098406/951875052188631120/Untitleasdasdd.png)

![Icon](https://media.discordapp.net/attachments/941386143168098406/951875051853054042/Untitleasdaasdsdd.png)

I wanted to be sure the user would know when the execution was done. For that, I used a message.box and I set it to be the type "question", so I could notify that the execution was done and also ask what the user would like to do next. 

![MessageBox](https://media.discordapp.net/attachments/941386143168098406/951876189818064916/Untitlgeasdaasdsdd.png)

##  

◽ Final considerations 

It was a simple project, the idea was to practice the things I've learned with the Windows Presentation Foundation Masterclass course :D 

Things I've practice: 
- MVVM 
- Logic building skills
- How to work with files 
- String handling 
- Inheritance 
- Interfaces (INotifyPropertyChanged and ICommand)
- How to style XAML
- Binding 

And much more!

