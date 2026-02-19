USE [BulgarianTraditionsAndCustomsDb]

GO
SET IDENTITY_INSERT [dbo].[Traditions] ON
GO
INSERT [dbo].[Traditions] ([Id], [Name], [Description], [CelebrationDate], [ImagePath], [Region], [TraditionType]) VALUES (1038, N'Сурва', N'Кукерските игри са древен обред за прогонване на злите сили и осигуряване на плодородие. Участниците носят страховити маски, кожи и големи хлопки. Шумът символично пречиства пространството и събужда природата. Често се разиграват обредни сценки със символика на брак и плодородие.', CAST(N'2026-02-13T00:00:00.0000000' AS DateTime2), N'/images/traditions/7f57019b-f79e-44b6-bc0e-988f109283d5_kukeri.jpg', 3, 9)
GO
INSERT [dbo].[Traditions] ([Id], [Name], [Description], [CelebrationDate], [ImagePath], [Region], [TraditionType]) VALUES (1039, N'Лазаруване', N'Лазаруването е обред за здраве и плодородие. Неомъжени момичета (лазарки) обикалят домовете, пеят песни и благославят стопаните. Обредът бележи прехода към моминство.', CAST(N'2026-04-04T00:00:00.0000000' AS DateTime2), N'/images/traditions/3043fb53-1244-4f8f-8d5d-33511a98a313_lazarkini.jpg', 3, 3)
GO
INSERT [dbo].[Traditions] ([Id], [Name], [Description], [CelebrationDate], [ImagePath], [Region], [TraditionType]) VALUES (1040, N'Коледуване', N'Коледари обикалят домовете и пеят благословии за здраве и берекет. Традицията е свързана с раждането на Христос и носи християнска символика.', CAST(N'2026-12-25T00:00:00.0000000' AS DateTime2), N'/images/traditions/d95fc955-df7d-4299-b3af-84c416e60afb_koledari1.jpg', 0, 9)
GO
INSERT [dbo].[Traditions] ([Id], [Name], [Description], [CelebrationDate], [ImagePath], [Region], [TraditionType]) VALUES (1041, N'Нестинарство', N'Нестинарството представлява ритуален танц върху жарава с икони на Св. Константин и Елена. Обредът съчетава християнски и езически елементи.', CAST(N'2026-06-03T00:00:00.0000000' AS DateTime2), N'/images/traditions/3ff24f14-04f0-428e-a2f2-9bc2c310df69_nestinarstvo.jpg', 7, 5)
GO
INSERT [dbo].[Traditions] ([Id], [Name], [Description], [CelebrationDate], [ImagePath], [Region], [TraditionType]) VALUES (1042, N'Трифон Зарезан', N'Обичай на лозарите. Извършва се ритуално зарязване на лозята за плодородие. Избира се „цар“, който символично ръководи празника.', CAST(N'2026-02-14T00:00:00.0000000' AS DateTime2), N'/images/traditions/307a2b18-e2c3-411d-bcad-55eba7638e25_trifon-zarezan.jpg', 6, 8)
GO
INSERT [dbo].[Traditions] ([Id], [Name], [Description], [CelebrationDate], [ImagePath], [Region], [TraditionType]) VALUES (1044, N'Баба Марта', N'На 1 март хората си разменят мартеници за здраве и късмет. Червеният цвят символизира живота и силата, а белият – чистотата. Мартеницата се носи до виждане на щъркел или цъфнало дърво.', CAST(N'2026-03-01T00:00:00.0000000' AS DateTime2), N'/images/traditions/6d609c01-30b4-4f82-a739-0cc3c7d1dbb2_baba-marta.jpg', 0, 3)
GO
INSERT [dbo].[Traditions] ([Id], [Name], [Description], [CelebrationDate], [ImagePath], [Region], [TraditionType]) VALUES (1045, N'Еньовден', N'Вярва се, че билките на този ден имат най-голяма лечебна сила. Събират се 77 и половина билки. Преминава се под еньовски венец за здраве.', CAST(N'2026-06-24T00:00:00.0000000' AS DateTime2), N'/images/traditions/85917b5f-71bc-4848-b96b-7c089cb19f13_eniovden.jpg', 9, 11)
GO
INSERT [dbo].[Traditions] ([Id], [Name], [Description], [CelebrationDate], [ImagePath], [Region], [TraditionType]) VALUES (1046, N'Сирни заговезни', N'Ден за прошка. По-младите искат прошка от по-възрастните. Палят се обредни огньове.', CAST(N'2026-02-22T00:00:00.0000000' AS DateTime2), N'/images/traditions/9ff2ffba-5f0d-4cdb-850a-27aabca4967e_sirni-zagovezni.jpg', 0, 5)
GO
INSERT [dbo].[Traditions] ([Id], [Name], [Description], [CelebrationDate], [ImagePath], [Region], [TraditionType]) VALUES (1047, N'Сурвакане', N'Сурвакането е една от най-характерните новогодишни традиции. Рано сутринта децата (най-често момчета) обикалят домовете и потупват възрастните по гърба със специално украсена дрянова пръчка – сурвачка. Докато сурвакат, изричат благословии за здраве, берекет и дълголетие. Дрянът се използва, защото е символ на здравина и издръжливост. В замяна децата получават лакомства, плодове или пари. Традицията има езически корени, но е обвързана с християнския празник Васильовден.', CAST(N'2026-01-01T00:00:00.0000000' AS DateTime2), N'/images/traditions/22c5dffc-3284-4498-a051-3bb727a06efb_survakane.jpg', 0, 7)
GO
INSERT [dbo].[Traditions] ([Id], [Name], [Description], [CelebrationDate], [ImagePath], [Region], [TraditionType]) VALUES (1048, N'Постна обредна трапеза на Бъдни вечер', N'На Бъдни вечер трапезата е изцяло постна и символична. Ястията трябва да са нечетен брой – 7, 9 или 11. Задължително присъстват боб, сарми, пълнени чушки, ошав, тиквеник, мед, орехи и чесън. Трапезата не се вдига през нощта, за да „дойдат душите на предците“. Всички стават едновременно, за да има сплотеност в семейството. Вярва се, че каквато е вечерта, такава ще бъде и годината.', CAST(N'2026-12-24T00:00:00.0000000' AS DateTime2), N'/images/traditions/a44df359-2cb6-4280-86fc-47ef07e98fc6_budni-vecher.jpg', 0, 5)
GO
INSERT [dbo].[Traditions] ([Id], [Name], [Description], [CelebrationDate], [ImagePath], [Region], [TraditionType]) VALUES (1049, N'Разчупване на обредната питка с пара', N'Приготвя се специална питка, в която се поставя пара. Най-възрастният мъж в семейството я разчупва. Първото парче е за Богородица или за къщата. Този, който намери парата, ще бъде най-щастлив и успешен през годината.', CAST(N'2026-12-24T00:00:00.0000000' AS DateTime2), N'/images/traditions/11fa0f88-29f1-4d5b-b3f4-41aea971c946_Обредна-празнична-питка.jpg', 0, 5)
GO
SET IDENTITY_INSERT [dbo].[Traditions] OFF
GO
SET IDENTITY_INSERT [dbo].[Participants] ON
GO
INSERT [dbo].[Participants] ([Id], [Name], [Description], [ImagePath]) VALUES (11, N'Кукери', N'Кукерите са маскирани мъже, облечени в кожи и страшни маски с хлопки. Те изпълняват шумни танци за прогонване на злото и осигуряване на плодородие. Произходът им е древен, предхристиянски.', N'/images/participants/ffca6b6a-042e-48cf-8e80-d6ee0026ea3e_kuker.jpg')
GO
INSERT [dbo].[Participants] ([Id], [Name], [Description], [ImagePath]) VALUES (12, N'Коледари', N'Коледарите са неженени млади мъже, които обикалят домовете в нощта срещу Коледа. Облечени са в народни носии и носят украсени геги. Те изпълняват специални песни и благословии според домакинството – за младоженци, за овчари, за стопани. Коледарите се възприемат като носители на божествена благословия и защита от злото.', N'/images/participants/b7907137-9868-4a9d-83bb-a7f3f598863d_koledari.jpg')
GO
INSERT [dbo].[Participants] ([Id], [Name], [Description], [ImagePath]) VALUES (13, N'Лазарки', N'Лазарките са неомъжени момичета, обикновено на възраст за женене, които участват в обичая лазаруване. Те носят традиционни носии, венци от цветя и пеят специални обредни песни за здраве, плодородие и благополучие. В народните вярвания участието в лазаруването е задължително условие за преминаване към моминство и бъдещ брак. Лазарките символизират пролетта, новия живот и женското начало.', N'/images/participants/ff72081a-ee05-463d-8b42-65c5e4eaef26_lazarki.jpg')
GO
INSERT [dbo].[Participants] ([Id], [Name], [Description], [ImagePath]) VALUES (15, N'Нестинари', N'Нестинарите са участници в ритуала нестинарство – танц върху жарава с икони в ръце. Те изпадат в религиозен транс под звуците на тъпан и гайда. Смята се, че са избрани и закриляни от Св. Константин и Елена. Ролята им е духовна и сакрална.', N'/images/participants/a348a297-2fd6-42a9-ba16-05416fa547a1_nestinarka.jpg')
GO
INSERT [dbo].[Participants] ([Id], [Name], [Description], [ImagePath]) VALUES (16, N'Лозари', N'Лозарите са основните участници в празника. Те отиват на лозята, извършват символично зарязване на лозите, поливат ги с вино и отправят благословии за плодородие. Вярва се, че правилното извършване на ритуала ще донесе богата реколта. Обредът има древни корени, свързани с култа към плодородието.', N'/images/participants/1a647ef1-9d47-46b2-a56f-b3479f5ad0dd_lozar.png')
GO
INSERT [dbo].[Participants] ([Id], [Name], [Description], [ImagePath]) VALUES (17, N'Станеник', N'Станеникът е водачът на коледарската група. Той е най-опитният и уважаем сред коледарите. Носи отговорност за реда в групата, започва песните и определя последователността на посещенията. Често държи украсена тояга или символичен жезъл.', N'/images/participants/60f4b4d8-6194-4b33-a0df-09924840db50_stanenik.jpg')
GO
INSERT [dbo].[Participants] ([Id], [Name], [Description], [ImagePath]) VALUES (18, N'Главен нестинар', N'Главният нестинар е духовният водач на общността. Той пази иконите и ръководи ритуала. Обикновено е наследствена роля и се предава в рода.', N'/images/participants/ea5ec604-cd81-4387-b080-89e01a35a162_glaven-nestinat.jpg')
GO
INSERT [dbo].[Participants] ([Id], [Name], [Description], [ImagePath]) VALUES (19, N'Булка', N'Булката е символичен персонаж в маскарадните игри. Обикновено ролята се изпълнява от мъж, облечен като жена. Символизира плодородие и продължаване на рода.', N'/images/participants/5cdf8760-dfa5-4629-8702-b5884ccc3e53_bulka-kukeri.jpg')
GO
INSERT [dbo].[Participants] ([Id], [Name], [Description], [ImagePath]) VALUES (20, N'Младоженец', N'Младоженецът е част от обредната „сватбена“ сценка в маскарадните игри. Заедно с булката символизира брака и възраждането на живота.', N'/images/participants/e1ffe256-5e1c-4e54-8535-1623fb83ad8b_mladozhenec-kukeri.jpg')
GO
INSERT [dbo].[Participants] ([Id], [Name], [Description], [ImagePath]) VALUES (21, N'Сурвакари', N'Деца, които на 1 януари обикалят домовете със сурвачка и изричат благословии. Те носят символиката на новото начало и чистотата.', N'/images/participants/cdad46d5-1d1a-4a35-8391-ffa569770359_img_8811.jpg')
GO
INSERT [dbo].[Participants] ([Id], [Name], [Description], [ImagePath]) VALUES (22, N'Стопанин на дома', N'Главата на семейството в традиционното българско домакинство. Той извършва основните обреди в дома – прекадяване на трапезата, разчупване на питката, палене на бъдника.', NULL)
GO
SET IDENTITY_INSERT [dbo].[Participants] OFF
GO
INSERT [dbo].[TraditionsParticipants] ([TraditionId], [ParticipantId], [ParticipantRole]) VALUES (1038, 11, N'Гонители на злото чрез маскарадни танци')
GO
INSERT [dbo].[TraditionsParticipants] ([TraditionId], [ParticipantId], [ParticipantRole]) VALUES (1038, 19, N'Обреден персонаж, играе се от мъж')
GO
INSERT [dbo].[TraditionsParticipants] ([TraditionId], [ParticipantId], [ParticipantRole]) VALUES (1038, 20, N'Обреден персонаж')
GO
INSERT [dbo].[TraditionsParticipants] ([TraditionId], [ParticipantId], [ParticipantRole]) VALUES (1039, 13, N'Обредни певици')
GO
INSERT [dbo].[TraditionsParticipants] ([TraditionId], [ParticipantId], [ParticipantRole]) VALUES (1040, 12, N'Благославящи')
GO
INSERT [dbo].[TraditionsParticipants] ([TraditionId], [ParticipantId], [ParticipantRole]) VALUES (1040, 17, N'Водач на групата')
GO
INSERT [dbo].[TraditionsParticipants] ([TraditionId], [ParticipantId], [ParticipantRole]) VALUES (1040, 22, N'Приема коледарите в дома си и ги дарява')
GO
INSERT [dbo].[TraditionsParticipants] ([TraditionId], [ParticipantId], [ParticipantRole]) VALUES (1041, 15, NULL)
GO
INSERT [dbo].[TraditionsParticipants] ([TraditionId], [ParticipantId], [ParticipantRole]) VALUES (1041, 18, N'Ритуален водач носещ иконите')
GO
INSERT [dbo].[TraditionsParticipants] ([TraditionId], [ParticipantId], [ParticipantRole]) VALUES (1042, 16, N'Ритуално зарязват лозе')
GO
INSERT [dbo].[TraditionsParticipants] ([TraditionId], [ParticipantId], [ParticipantRole]) VALUES (1042, 22, N'Организира трапезата')
GO
INSERT [dbo].[TraditionsParticipants] ([TraditionId], [ParticipantId], [ParticipantRole]) VALUES (1047, 21, N'Благославящи деца')
GO
INSERT [dbo].[TraditionsParticipants] ([TraditionId], [ParticipantId], [ParticipantRole]) VALUES (1048, 22, N'Прекадява трапезата')
GO
INSERT [dbo].[TraditionsParticipants] ([TraditionId], [ParticipantId], [ParticipantRole]) VALUES (1049, 22, N'Разчупва питката')
GO
SET IDENTITY_INSERT [dbo].[Holidays] ON
GO
INSERT [dbo].[Holidays] ([Id], [Name], [CelebrationDate], [Description]) VALUES (7, N'Гергьовден', CAST(N'2026-05-06T00:00:00.0000000' AS DateTime2), N'Празник, свързан с началото на лятната стопанска година. Принася се курбан (агне), извършват се ритуали за здраве и плодородие.')
GO
INSERT [dbo].[Holidays] ([Id], [Name], [CelebrationDate], [Description]) VALUES (8, N'Цветница', CAST(N'2026-03-29T00:00:00.0000000' AS DateTime2), N'Цветница е християнски празник, посветен на влизането на Иисус Христос в Йерусалим в навечерието на Страстната седмица, поради което е наричан и Вход Господен. Отбелязва се с променлива дата, в неделята седмица преди Великден. Освещават се върбови клонки в църквата. Празнуват имен ден хората с имена на цветя.')
GO
INSERT [dbo].[Holidays] ([Id], [Name], [CelebrationDate], [Description]) VALUES (9, N'Димитровден', CAST(N'2026-10-26T00:00:00.0000000' AS DateTime2), N'Димитровден е народен и православен празник, отбелязван на 26 октомври в памет на свети великомъченик Димитър Солунски. Смята се за край на стопанската година. На този ден се разплащат надници и се сключват нови договори.')
GO
INSERT [dbo].[Holidays] ([Id], [Name], [CelebrationDate], [Description]) VALUES (10, N'Лазаровден', CAST(N'2026-04-04T00:00:00.0000000' AS DateTime2), N'Лазаровден е християнски празник, посветен на възкресяването на Лазар от Иисус Христос. В българската традиция обаче празникът има силно изразен фолклорен характер. Свързва се с пролетното пробуждане на природата, плодородието и прехода от детство към моминство. Вярва се, че момиче, което не е лазарувало, не може да се омъжи. Затова в миналото участието в обичая било задължително за неомъжените девойки. Празникът символизира новия живот – както в религиозен, така и в природен смисъл.')
GO
INSERT [dbo].[Holidays] ([Id], [Name], [CelebrationDate], [Description]) VALUES (11, N'Рождество Христово (Коледа)', CAST(N'2026-12-25T00:00:00.0000000' AS DateTime2), N'Рождество Христово е един от най-големите християнски празници, отбелязващ раждането на Иисус Христос във Витлеем. В българската традиция празникът съчетава християнска символика с древни народни вярвания, свързани с новото начало и светлината. Коледа е празник на семейството, дома и благословията. След 40-дневния пост настъпва тържествена трапеза. В народните вярвания това е време, когато небето „се отваря“, а молитвите имат особена сила.')
GO
INSERT [dbo].[Holidays] ([Id], [Name], [CelebrationDate], [Description]) VALUES (12, N'Св. Константин и Елена', CAST(N'2026-05-21T00:00:00.0000000' AS DateTime2), N'Празникът е посветен на светите равноапостолни император Константин Велики и майка му Елена. В българската традиция той има особено значение в Странджа, където е свързан с мистичния обред нестинарство – танц върху жарава с икони в ръце. Вярва се, че нестинарите изпадат в религиозен транс и получават божествена закрила. Празникът съчетава християнска почит към светците и древни езически огнени ритуали, символизиращи пречистване и обновление.')
GO
INSERT [dbo].[Holidays] ([Id], [Name], [CelebrationDate], [Description]) VALUES (13, N'Нова година', CAST(N'2026-01-01T00:00:00.0000000' AS DateTime2), N'Нова година бележи началото на календарната година. В България празникът съчетава светски и религиозни елементи, тъй като съвпада с църковния празник Васильовден. Смята се за време на ново начало, късмет и пожелания за здраве и берекет. Народните вярвания отдават голямо значение на първия гост в дома (полазник), който символично определя късмета през годината. Празникът е свързан със семейни събирания, празнична трапеза и благословии.')
GO
INSERT [dbo].[Holidays] ([Id], [Name], [CelebrationDate], [Description]) VALUES (14, N'Бъдни вечер', CAST(N'2026-12-24T00:00:00.0000000' AS DateTime2), N'Бъдни вечер е навечерието на Рождество Христово и един от най-важните семейни празници в българската традиция. Денят е последен от Коледния пост и трапезата е изцяло постна. Вечерята има силно символичен характер – нечетен брой ястия, обредна питка с пара, палене на бъдник. Вярва се, че тази нощ небето се отваря и желанията се сбъдват. Трапезата не се вдига, за да могат душите на починалите предци да „гостуват“. Празникът символизира очакването на раждането на Христос и духовното пречистване.')
GO
SET IDENTITY_INSERT [dbo].[Holidays] OFF
GO
INSERT [dbo].[HolidayTradition] ([HolidaysId], [TraditionsId]) VALUES (10, 1039)
GO
INSERT [dbo].[HolidayTradition] ([HolidaysId], [TraditionsId]) VALUES (11, 1040)
GO
INSERT [dbo].[HolidayTradition] ([HolidaysId], [TraditionsId]) VALUES (12, 1041)
GO
INSERT [dbo].[HolidayTradition] ([HolidaysId], [TraditionsId]) VALUES (13, 1047)
GO
INSERT [dbo].[HolidayTradition] ([HolidaysId], [TraditionsId]) VALUES (14, 1048)
GO
INSERT [dbo].[HolidayTradition] ([HolidaysId], [TraditionsId]) VALUES (14, 1049)
GO
