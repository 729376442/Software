using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFT.Visual;
using EscapeFromTarkovCheat.Feauters;
using UnityEngine;

namespace EscapeFromTarkovCheat.Utils
{
    class Settings
    {
        internal static bool DrawLootItems = true;
        internal static bool DrawNearbyLootItems = true;
        internal static bool DrawDeadBodyItems = false;
        internal static bool DrawLootableContainers = true;
        internal static bool DrawPlayerLoots = false;
        internal static bool DrawExfiltrationPoints = false;

        internal static bool DrawPlayers = false;
        internal static bool PlayerCache = true;
        internal static bool DrawPlayerName = true;
        internal static bool DrawPlayerHealth = false;
        internal static bool DrawPlayerBox = true;
        internal static bool DrawPlayerLine = false;
        internal static bool DrawPlayerSkeleton = false;

        internal static float DrawLootItemsDistance = 10f;
        internal static float DrawLootableContainersDistance = 10f;
        internal static float DrawPlayersDistance = 4000f;
        internal static float DrawPlayerSkeletonDistance = DrawPlayersDistance;

        internal static bool ForceThermal = false;
        internal static bool GodMode = false;
        internal static bool HalfGodMode = true;
        internal static bool SpeedHack = false;
        internal static float SpeedMulti = 50f;
        internal static float PlayerCacheInterval = 5f;

        internal static bool ValuableToggle = true;
        internal static bool WishListAmmoToggle = true;
        internal static bool WishListGearPlateToggle = true;
        internal static bool WishListConsumableToggle = true;
        internal static bool CheckPCItemAmmoToggle = false;
        internal static bool CheckPCItemGearPlateToggle = true;
        internal static bool TemporaryItemListToggle = true;


        internal static bool LootMode = false;
        internal static bool LootGroup1 = false;
        internal static bool LootGroup2 = false;
        internal static bool LootGroup3 = false;
        internal static bool LootGroup4 = false;
        internal static bool DogTagLV60 = false;

        internal static bool FinishQuest = false;
        internal static bool IncreaseTraderStanding = false;

        internal static KeyCode SpeedHackKey = (KeyCode)284;//F3
        internal static KeyCode ThermalToggle = (KeyCode)285;//F4
        internal static KeyCode TeleportWishList = (KeyCode)286;//F5
        internal static KeyCode TeleportLootItem = (KeyCode)287;//F6

        internal static KeyCode UnlockDoors = (KeyCode)290;//F9
        internal static KeyCode KillAll = (KeyCode)291;//F10
        internal static KeyCode TeleportMarkedEnemies = (KeyCode)292;//F11
        internal static KeyCode TeleportAllEnemies = (KeyCode)293;//F12

        internal static string OfflineStreetStatus = "Off";
        internal static string idList = "";
        internal static int DamageReduction = 16;
        internal static int HealPerSec = 4;
        internal static int BaseHealPerSec = 1;
        internal static int LoadSpeed = 38;
        internal static int UnloadSpeed = 36;

        internal static bool BloodBathModeBoss = false;
        internal static bool BloodBathModePMC = false;
        internal static bool AutoArmor = false;
        internal static bool AutoRefreshArmor = true;
        internal static float AutoRefreshArmorInterval = 12f;
        internal static int SpawnCount = 2;
        internal static int SpawnInterval = 12;

        //Done
        internal static List<string> TraderList = new List<string> {
            "54cb50c76803fa8b248b4571",//Prapor
            "54cb57776803fa99248b456e",//Therapist
            "58330581ace78e27b8b10cee",//Skier
            "5935c25fb3acc3127c3d8cd9",//PeaceKeeper
            "5a7c2eca46aef81a7ca2145d",//Mechanic
            "5ac3b934156ae10c4430e83c",//Ragman
            "5c0647fdd443bc2504c2d371",//Jaeger
            "638f541a29ffd1183d187f57",//LightKeeper
            //"579dc571d53a0658a154fbec",//Fence
            //"656f0f98d80a697f855d34b1",//BTR
        };
                
        //Done
        internal static List<string> Filter_Keycard_Container = new List<string> {
            "60b0f6c058e0b0481a09ad11",//WZ钱包
            "62a09d3bcf4a99369e262447",//Gingy
            "5783c43d2459774bbe137486",//钱包
            "5e42c83786f7742a021fdf3c",//#21WS卡
            "5e42c81886f7742a01529f57",//#11SR卡
            //"619cbf7d23893217ec30b689",//注射器包
            //"5c093e3486f77430cb02e593",//狗牌包
            //"59fafd4b86f7745ca07e1232",//钥匙收纳器
        };
        
        //Done
        internal static List<string> Category_Keycard_Container = new List<string> {
            "5c164d2286f774194c5e69fa",//Keycard
            "5795f317245977243854e041",//SimpleContainer

            //容器
            //"5d235bb686f77443f4331278",//容器-SICC
            //"590c60fc86f77412b13fddcf",//容器-文件包
            //"59fafd4b86f7745ca07e1232",//容器-钥匙串
            //"619cbf7d23893217ec30b689",//容器-注射器包
            //"619cbf9e0a7c3a1a2731940a",//容器-钥匙卡包
            //"5c093e3486f77430cb02e593",//容器-狗牌包
            //"5aafbde786f774389d0cbc0f",//容器-弹药箱

            //钥匙卡
            //"5c94bbff86f7747ee735c08f",//白卡
            //"5c1d0f4986f7744bb01837fa",//黑卡
            //"5c1d0dc586f7744baf2e7b79",//绿卡
            //"5c1e495a86f7743109743dfb",//紫卡
            //"5c1d0c5f86f7744bb2683cf0",//蓝卡
            //"5c1d0d6d86f7744bb2683e1f",//黄卡
            //"5c1d0efb86f7744baf2e7b7b",//红卡
            //"66acd6702b17692df20144c0",//工厂卡
        };
        
        //高价值 机械钥匙 Done
        internal static List<string> Valuable = new List<string> {
            "5c12613b86f7743bbe2c3f76",//情报
            "6389c8c5dbfd5e4b95197e6b",//蓝情报
            "5c0126f40db834002a125382",//RR冰镐
            "5c0530ee86f774697952d952",//LEDX
            "59faff1d86f7746c51718c9c",//Bitcoin
            "5d1b376e86f774252519444e",//私酒
            "5c052e6986f7746b207bc3c9",//AED
            "57347ca924597744596b4e71",//显卡
            "5d0378d486f77420421a5ff4",//滤波器
            //"5d235b4d86f7742e017bc88a",//GP coin
            
            "5d80c60f86f77440373c4ece",//RB-BK
            "5d80c62a86f7744036212b3f",//RB-VO
            "5ede7a8229445733cb4c18e2",//RB-PKPM
            "62987dfc402c7f69bf010923",//套间符号钥匙
            "63a3a93f8a56922e82001f5d",//工厂符号钥匙
            "5780cf7f2459777de4559322",//海关符号钥匙
            "64ccc25f95763a1ae376e447",//街区符号钥匙
            "63a39fc0af870e651d58e6ae",//Chekannaya 15号公寓钥匙
            "5ad5d7d286f77450166e0a89",//Kiba商店钥匙
            "5e42c71586f7747f245e1343",//ULTRA 医疗仓库钥匙
            "63a397d3af870e651d58e65b",//车行封闭区域钥匙
            "64d4b23dc1b37504b41ac2b6",//生锈的带血钥匙

            "5c052f6886f7746b1e3db148",//军用电台

            //任务道具
            //"6331bb0d1aa9f42b804997a6",//V3 U盘
        };

        //临时需求
        internal static List<string> TemporaryItemList = new List<string> {
        };

        internal static List<string> LootItemList = new List<string> {
            //IOTV Gen4 全防护
            //"5c05300686f7746dce784e5d",//VPX

            //鱼鹰
            //"590c37d286f77443be3d7827",//SAS
            
            //Rys-T面罩 Vulkan-5 面罩
            //"5d03784a86f774203e7e0c4d",//有机玻璃

            //REAP-IR 热成像
            //"59e3647686f774176a362507",//木头钟
            //"59faf7ca86f7740dbe19f6c2",//劳力士
            //"5d235a5986f77443f6329bc6",//金骷髅
            "6389c7750ef44505c87f5996",//微控制器电路板
            "6389c7f115805221fb410466",//GPS
            
            //FLIR 热成像
            //"5d0377ce86f774186372f689",//热成像模块
            //"5d0376a486f7747d8050965c",//军用电路板
            //"5d03784a86f774203e7e0c4d",//军用转速计

        };

        internal static List<string> LootItem_CategoryFilter = new List<string> {
            "543be5cb4bdc2deb348b4568",//弹药
            "5485a8684bdc2da71d8b4567",//成包弹药
            "55802f3e4bdc2de7118b4584",//GearMod
            "550aa4154bdc2dd8348b456b",//FunctionalMod
            "55802f4a4bdc2ddb688b4569",//MasterMod
            "543be5dd4bdc2deb348b4569",//Money
            "543be6674bdc2df1348b4569",//FoodDrink
            "644120aa86ffbe10ee032b6f",//ArmorPlate
            "5448f3a64bdc2d60728b456a",//注射器
            "5c99f98d86f7745c314214b3",//机械钥匙
            //"5448e54d4bdc2dcc718b4568",//Armor
            //"5448e5284bdc2dcb718b4567",//Vest
            //"5422acb9af1c889c16000029",//Weapon

        };

        internal static List<string> LootItem_SingleFilter = new List<string> {
            "5ca20abf86f77418567a43f2",//Triton
            "5e4abb5086f77406975c9342",//6级甲-LBT-6094A 前后插板
            "6038b4ca92ec1c3103795a0d",//6级甲-LBT-6094A 前后插板
            "6038b4b292ec1c3103795a0b",//6级甲-LBT-6094A 前后插板
            "5c010e350db83400232feec7",//SP-8
            "5448be9a4bdc2dfd2f8b456a",//RGD-5
            "5648a69d4bdc2ded0b8b457b",//BlackRock
            "544a5cde4bdc2d39388b456b",//MBSS
            "61bc85697113f767765c7fe7",//MMAC
            "656f198fb27298d6fd005466",//Dragon Egg
            "",//
            "",//
            "",//
            "",//
            "",//
            "56e33680d2720be2748b4576",//小挎包
            "5e4abfed86f77406a2713cf7",//TARZAN
            "5ab8f4ff86f77431c60d91ba",//幽灵
            "5d235b4d86f7742e017bc88a",//GP coin
            "64be7110bf597ba84a0a41ea",//56式胸挂
            "5ca2151486f774244a3b8d30",//Redut-M
            "56e33634d2720bd8058b456b",//旅行包
            "59e7715586f7742ee5789605",//防毒
            "5ab8f85d86f7745cd93a1cf5",//提花
            "59e7635f86f7742cbf2c1095",//3M
            "66b5f693acff495a294927e3",//ComTac V
            "590c595c86f7747884343ad7",//滤罐
            "64be79e2bf8412471d0d9bcc",//Kora-Kulon
            "5c0e57ba86f7747fa141986d",//6B23-2
            "5aa2b9aee5b5b00015693121",//雷硼
            "5c0e51be86f774598e797894",//6B13
            "5c0e53c886f7747fa54205c7",//6B13
            "6389c85357baa773a825b356",//直流变压器
            "5710c24ad2720bc3458b45a3",//F-1
            "6033fa48ffd42c541047f728",//M32
            "5d03794386f77420415576f5",//坦克电池
            "5ab8e79e86f7742d8b372e78",//BNTI Gzhel-K body armor
            "58d3db5386f77426186285a0",//M67
            "5c0e5edb86f77461f55ed1f7",//BNTI Zhuk body armor (Press)
            "64be79c487d1510151095552",//Kora-Kulon
            "57235b6f24597759bf5a30f1",//PVS-14
            "590c37d286f77443be3d7827",//SAS
            "607f20859ee58b18e41ecd90",//PACA
            "62a09d79de7ac81993580530",//DRD
            "572b7adb24597762ae139821",//Scav背心
            "5df8a2ca86f7740bfe6df777",//6B2
            "5ab8e4ed86f7742d8e50c7fa",//MF-UN
            "5648a7494bdc2d9d488b4583",//PACA
            "5e2af51086f7746d3f3c3402",//引信
            "62178be9d0050232da3485d9",//照明棒
            "627bce33f21bc425b06ab967",//MSGL
            "5aa2ba71e5b5b000137b758f",//Sordin
            "5c0d2727d174af02a012cf58",//DJETA
            "64abd93857958b4249003418",//OVT
            "6040dd4ddcf9592f401632d2",//Azimut
            "603648ff5a45383c122086ac",//Azimut
            "5f60b85bbdb8e27dee3dc985",//Caiman BA
            "59e770b986f7742cbd762754",//AF目镜
            "5a16b9fffcdbcb0176308b34",//RAC
            "59fafb5d86f774067a6f2084",//丙烷
            "5d1b371186f774253763a656",//野营燃料桶
            "5733279d245977289b77ec24",//蓄电池
            "62a0a0bb621468534a797ad5",//master
            "544fb45d4bdc2dee738b4568",//Salewa
            "590c678286f77426c9660122",//IFAK
            "5b43575a86f77424f443fe62",//燃油添加剂
            "590a373286f774287540368b",//固态燃料
            "5d1b39a386f774252339976f",//软管
            "59e35cbb86f7741778269d83",//管子
            "577e1c9d2459773cd707c525",//打印纸
            "5c13cef886f774072e618e82",//厕纸
            "61bf83814088ec1a363d7097",//针线盒
            "590c35a486f774273531c822",//绿瓶密封胶
            "590c346786f77423e50ed342",//黄瓶密封胶
            "59e3556c86f7741776641ac2",//漂白剂
            "5d40412b86f7743cb332ac3a",//洗发水
            "5d1b317c86f7742523398392",//手钻
            "63a0b208f444d32d6f03ea1e",//重击锤
            "5d1c774f86f7746d6620f8db",//散热器
            "5d1b31ce86f7742523398394",//R形钳子
            "590c311186f77424d1667482",//扳手
            "590c2b4386f77425357b6123",//钳子
            "590c2d8786f774245b1f03f3",//螺丝刀
            "5d63d33b86f7746ea9275524",//螺丝刀
            "5d4042a986f7743185265463",//螺丝刀
            "59faf98186f774067b6be103",//碱
            "57347c2e24597744902c94a1",//PSU
            "59e36c6f86f774176c10a2a7",//电源线
            "5d03775b86f774203e7e0c4b",//相控阵
            "590c657e86f77412b013051d",//灰熊包
            "5e2af2bc86f7746d3f3c33fc",//火柴
            "57347b8b24597737dd42e192",//火柴
            "59e3647686f774176a362507",//木头钟
            "5e54f62086f774219b0f1937",//乌鸦
            "590de71386f774347051a052",//古董茶壶
            "5e2af29386f7746d4159f077",//KEK
            "59e3658a86f7741776641ac4",//猫雕像
            "5e2af22086f7746d3f3c33fa",//冷焊膏
            "5af04b6486f774195a3ebb49",//精英钳子
            "5c13cd2486f774072c757944",//肥皂
            "62a091170b9d3c46de5b6cf2",//鹦鹉
            "5d1b327086f7742525194449",//压力表
            "59e366c186f7741778269d85",//有机玻璃
            "5d40419286f774318526545f",//金属剪刀
            "62a0a098de7ac8199358053b",//缝纫锤
            "590c5c9f86f77477c91c36e7",//WD-40 400
            "590c5bbd86f774785762df04",//WD-40 100
            "619cbf476b8a1b37a54eebf8",//军用软管
            "57347c77245977448d35f6e2",//螺母
            "57347c5b245977448d35f6e1",//螺栓
            "573475fb24597737fb1379e1",//香烟
            "5d1b3a5d86f774252167ba22",//一堆药
            "573474f924597738002c6174",//银链
            "5d1b392c86f77425243e98fe",//灯泡
            "60391b0fb847c71012789415",//TP-200
            "5b4335ba86f7744d2837a264",//输血工具
            "5672cb124bdc2d1a0f8b4568",//AA电池
            "590a358486f77429692b2790",//充电电池
            "5672cb304bdc2dc2088b456a",//D型电池
            "5734758f24597738025ee253",//金链
            "5d40425986f7743185265461",//nippers
            "590a3d9c86f774385926e510",//紫外线灯
            "5e2af37686f774755a234b65",//打火机
            "590a3c0a86f774385a33c450",//火花塞
            "5d0377ce86f774186372f689",//热成像模块
            "6389c6463485cf0eeb260715",//wheat
            "5d0375ff86f774186372f685",//军用电缆
            "5e2af02c86f7746d420957d4",//氯
            "590c31c586f774245e3141b2",//钉子
            "59e35ef086f7741777737012",//螺丝
            "5af0484c86f7740f02001f7f",//普通咖啡豆
            "56742c284bdc2d98058b456d",//crickent
            "56742c2e4bdc2d95058b456d",//zibbo
            "544fb25a4bdc2dfb738b4567",//绷带
            "544fb37f4bdc2dee738b4567",//止痛药
            "57347c1124597737fb1379e3",//duct tape
            "5734779624597737e04bf329",//cpu风扇
            "573477e124597737dd42e191",//CPU
            "60391afc25aff57af81f7085",//RATCHET
            "5e2aee0a86f774755a234b62",//CYCLON
            "5d02778e86f774203e7dedbe",//CMS
            "5734770f24597738025ee254",//香烟
            "573476f124597737e04bf328",//香烟
            "573476d324597737da2adc13",//香烟
            "5c06782b86f77426df5407d2",//电容
            "5e2af00086f7746d3f3c33f7",//洁厕灵
            "590a3efd86f77437d351a25b",//气体分析仪
            "5bc9c049d4351e44f824d360",//古董书
            "59e358a886f7741776641ac3",//clin
            "5d1b309586f77425227d1676",//破损LCD
            "5d1b32c186f774252167a530",//温度表
            "5e2aef7986f7746d3f3c33f5",//杀虫剂
            "59e3596386f774176c10a2a2",//PAID
            "5751a25924597722c463c472",//绷带
            "5d1b3f2d86f774253763b735",//注射器
            "590de7e986f7741b096e5f32",//古董花瓶
            "59e3639286f7741777737013",//狮雕
            "544fb3364bdc2d34748b456a",//骨折板
            "57347cd0245977445a2d6ff1",//T插座
            "6389c6c7dbfd5e4b95197e68",//净水片
            "5e831507ea0a7c419c2f9bd9",//止血带
            "619cc01e0a7c3a1a2731940c",//医疗器械
            "59e3606886f77417674759a5",//生理盐水
            "590a3b0486f7743954552bdb",//电路板
            "62a0a043cf4a99369e2624a5",//维生素
            "5e2af41e86f774755a234b67",//布
            "5e2af4d286f7746d4159f07a",//布
            "5e2af47786f7746d404f3aaa",//布
            "5c12620d86f7743f8b198b72",//游戏机
            "60098af40accd37ef2175f27",//CAT
            "5734795124597738002c6176",//胶带
            "56742c324bdc2d150f8b456d",//损坏GPhone
            "5bc9b720d4351e450201234b",//黄金GPhone
            "590a386e86f77429692b27ab",//HDD
            "5f745ee30acaeb0d490d8c5b",//吉他拨片
            "5755383e24597772cb798966",//凡士林
            "590c695186f7741e566b64a2",//力百汀
            "5bc9bdb8d4351e003562b8a1",//徽章
            "5c1267ee86f77416ec610f72",//PRO-KILL
            "590a391c86f774385a33c404",//磁铁
            "60391a8b3364dc22b04d0ce5",//铝热剂
            "5d1b313086f77425227d1678",//中继器
            "5909e99886f7740c983b9984",//USB-A
            "5af0534a86f7743b6f354284",//检眼镜
            "57347baf24597738002c6178",//RAM
            "590c2c9c86f774245b1f03f2",//测量卷尺
            "59e35de086f7741778269d84",//电钻
            "619cbfeb6b8a1b37a54eebfa",//Bulbex
            "590c639286f774151567fa95",//技术指导文件
            "590c661e86f7741e566b646a",//车载急救包
            "5755356824597772cb798962",//AI-2
            "573478bc24597738002c6175",//马雕像
            "62a09cb7a04c0c5c6e0a84f8",//记者证
            "54491bb74bdc2d09088b4567",//刺刀
            "655c67782a1356436041c9c5",//RYZHY
            "655c673673a43e23e857aebd",//SCAV
            "655c669103999d3c810c025b",//邪教徒
            "66572c82ad599021091c6118",//killa
            "655c66e40b2de553b618d4b8",//Mutkevich
            "66572be36a723f7f005a066e",//Reshala
            "655c652d60d0ac437100fed7",//BEAR
            "655c663a6689c676ce57af85",//USEC
            "66572cbdad599021091c611a",//TAGLIA
            "66572b8d80b1cd4b6a67847f",//DEN
            "655c67ab0d37ca5135388f4b",//圣诞老人
            "5bc9bc53d4351e00367fbcee",//金鸡
            "61bf7b6302b3924be92fa8c3",//金属零件
            "5e2af4a786f7746d3f3c3400",//布
            "619cbfccbedcde2f5b3f7bdd",//管道扳手
            "5734781f24597737e04bf32a",//DVD
            "590c645c86f77412b01304d9",//日记
            "5d0379a886f77420407aa271",//炮弹
            "62a09ee4cf4a99369e262453",//白盐
            "590c651286f7741e566b6461",//袖珍日记
            "5bc9b355d4351e6d1509862a",//枪油
            "6389c70ca33d8c4cdf4932c6",//电子元件
            "5c06779c86f77426e00dd782",//电线
            "59e361e886f774176c10a2a5",//H2O2
            "5bc9b9ecd4351e3bac122519",//胡须油
            "62a09cfe4f842e1bd12da3e4",//金蛋
            "5c1265fc86f7743f896a21c2",//GPX
            "5751a89d24597722aa0e8db0",//金星
            "5c12688486f77426843c7d32",//绳索
            "5c066e3a0db834001b7353f0",//N-15
            "590c2e1186f77425357b6124",//一套工具
            "62a0a124de7ac81993580542",//地图调查
            "5c052fb986f7746b2101e909",//RFID
            "61bf7c024770ee6f9c6b8b53",//加密磁盘
            "59e35abd86f7741778269d82",//小苏打
            "5d4041f086f7743cac3f22a7",//小牙膏
            "59faf7ca86f7740dbe19f6c2",//劳力士
            "5d235a5986f77443f6329bc6",//金骷髅
            "60b0f561c4449e4cb624c1d7",//老鼠药
            "5bc9c377d4351e3bac12251b",//火钳
            "62a09e73af34e73a266d932a",//bakeEzy
            "5d0376a486f7747d8050965c",//MCB
            "5d1b304286f774253763a528",//可用LCD
            "5bc9be8fd4351e00334cae6e",//42茶
            "62a08f4c4f842e1bd12d9d62",//bear熊玩具
            "5d1b2ffd86f77425243e8d17",//NIXXOR
            "590c621186f774138d11ea29",//U盘
            "62a09e974f842e1bd12da3f0",//天雷地火
            "62a09ec84f842e1bd12da3f2",//叉车钥匙
            "5c0696830db834001d23f5da",//PNV-10T
            "5d03784a86f774203e7e0c4d",//MGT
            "5b432f3d5acfc4704b4a1dfb",//Momex
            "5c05300686f7746dce784e5d",//VPX
            "5c05308086f7746b2101e90b",//Virtex
            "5e54f6af86f7742199090bf3",//Lupo's
            "572b7fa524597762b747ce82",//面巾
            "66b37f114410565a8f6789e2",//Inseq
            "66b37ea4c5d72b0277488439",//Tamatthi
            "60b0f6c058e0b0481a09ad11",//WZ钱包
            "62a09d3bcf4a99369e262447",//Gingy
            "5783c43d2459774bbe137486",//钱包
            "5e42c83786f7742a021fdf3c",//#21WS卡
            "5e42c81886f7742a01529f57",//#11SR卡
            "66b37eb4acff495a29492407",//Viibiin
            "60b0f7057897d47c5b04ab94",//Loot Lord
            "5d1c819a86f774771b0acd6c",//武器零件
            "5d6fc87386f77449db3db94e",//火药
            "5d6fc78386f77449d825f9dc",//火药
            "590c5a7286f7747884343aea",//火药
            "5672cb724bdc2dc2088b456b",//盖格计数器
            "5ac8d6885acfc400180ae7b0",//Fast MT Tan
            "5aa2b9ede5b5b000137b758b",//牛仔帽
            "5aa2b87de5b5b00016327c25",//BEAR
            "5aa2ba46e5b5b000137b758d",//UXPRO
            "5c0e655586f774045612eeb2",//Trooper
            "5c165d832e2216398b5a7e36",//战术运动型
            "5e4d34ca86f774264f758330",//Razor
            "5b40e3f35acfc40016388218",//ACHHC
            "5d6d3716a4b9361bc8618872",//LSHZ-2DTM
            "5f60cd6cf2bcbb675b00dac6",//XCEL
            "609e8540d5c319764c2bc2e9",//THOR CV
            "5b44d22286f774172b0c9de8",//Kirasa
            "59e7708286f7742cbd762753",//苏联毛帽
            "628e4e576d783146b124c64d",//ComTac 4
            "5aa2b87de5b5b00016327c25",//BEAR
            "5b40e5e25acfc4001a599bea",//BEAR
            "5b40e61f5acfc4001a599bec",//USEC
            "5aa2a7e8e5b5b00016327c16",//USEC
            "5b40e4035acfc47a87740943",//ACHHC
            "5aa2ba19e5b5b00014028f4e",//羊绒帽
            "5aa7d193e5b5b000171d063f",//SFERA
            "5ab8f39486f7745cd93a1cca",//CF
            "5b40e2bc5acfc40016388216",//ULACH
            "62a0a16d0b9d3c46de5b6e97",//军用闪存
            "5c0558060db834001b735271",//四眼夜视仪
            "5af0561e86f7745f5f3ad6ac",//充电宝
            "5c052f6886f7746b1e3db148",//军用信号
            "5e2aedd986f7746d404f3aa4",//绿电池
            "5d1b2fa286f77425227d1674",//马达
            "590a3cd386f77436f20848cb",//节能灯
            "57347c93245977448d35f6e3",//牙膏
            "5c10c8fd86f7743d7d706df3",//肾上腺素
            "544fb3f34bdc2d03748b456a",//吗啡
            "6389c7750ef44505c87f5996",//微控制器电路板
            "6389c7f115805221fb410466",//GPS

            "60098ad7c2240c0fe85c570a",//AFAK
            "5d02797c86f774203f38e30a",//黑手术包
            "5af0454c86f7746bf20992e8",//铝夹板
            "5e8488fa988a8701445df1e4",//止血剂
            "5af0548586f7743a532b7e99",//布洛芬
            "5910968f86f77425cf569c32",//武器维修
            "591094e086f7747caa7bb2ef",//护甲维修
            "59e3577886f774176a362503",//糖
            "5d1b385e86f774252167b98a",//滤水器
            "5d1b36a186f7742523398433",//金属燃料桶
            "5d1b2f3f86f774252167a52c",//FP-100

        }; 

        internal static List<string> LootItem_WeaponFilter = new List<string> {
            "624c2e8614da335f1e034d8c",//CR 200DS
            "620109578d82e67e7911abf2",//信号枪
            "66015072e9f84d5680039678",//玩具枪
            "5a7ae0c351dfba0017554310",//GLOCK 17
            "644674a13d52156624001fbc",//9A-91
            "661ceb1b9311543c7104149b",//M60E6
            "668fe5a998b5ad715703ddd6",//沙漠之鹰Mk XIX
            "645e0c6b3b381ede770e1cc9",//VSK94
            "5c501a4d2e221602b412b540",//Hunter
            "64748cb8de82c85eaf0a273a",//MP43 截短
            "5aafa857e5b5b00018480968",//M1A
            "5ae08f0a5acfc408fb1398a1",//Mosin Sniper
            "5bfd297f0db834001a669119",//Mosin Infantry
            "5cadfbf7ae92152ac412eeef",//ASH-12
            "669fa409933e898cce0c2166",//沙漠之鹰L5
            "5e81c3cbac2bb513793cdc75",//M1911A1
            "628b5638ad252a16da6dd245",//AK-545
            "623063e994fc3f7b302a9696",//G36
            "5448bd6b4bdc2dfc2f8b4569",//PM
            "618428466ef05c2ce828f218",//SCAR-L
            "58948c8e86f77409493f7266",//MPX
            "5c07c60e0db834002330051f",//ADAR 2-15
            "57838ad32459774a17445cd2",//VSS
            "6680304edadb7aa61d00cef0",//UZI PRO Pistol
            "6499849fc93611967b034949",//AK-12
            "651450ce0e00edc794068371",//SR-3M
            "668e71a8dadf42204c032ce1",//UZI PRO冲锋枪
            "574d967124597745970e7c94",//SKS
            "5abccb7dd8ce87001773e277",//APB
            "576a581d2459771e7b1bc4f1",//MP-443 "乌鸦"
            "6193a720f8ee7e52e42109ed",//USP .45
            "59e6687d86f77411d949b251",//VPO-209
            "5abcbc27d8ce8700182eceeb",//AKMSN
            "5ac66cb05acfc40198510a10",//AK-101
            "5df8ce05b11454561e39243b",//SR-25
            "5bd70322209c4d00d7167b8f",//MP7A2
            "571a12c42459771f627b58a0",//TT-33
            "54491c4f4bdc2db1078b4568",//MP-133
            "587e02ff24597743df3deaeb",//OP-SKS
            "5bf3e0490db83400196199af",//AKS-74
            "583990e32459771419544dd2",//AKS-74UN
            "5cc82d76e24e8d00134b4b83",//P90
            "5fb64bc92b1b027b1f50bcf2",//VECTOR .45 ACP
            "5fc3f2d5900b1d5091531e57",//VECTOR 9x19
            "5a367e5dc4a282000e49738f",//RSASS
            "5e848cc2988a8701445df1e8",//KS-23M
            "5ac66d9b5acfc4001633997a",//AK-105
            "59984ab886f7743e98271174",//PP-19
            "57d14d2524597714373db789",//PP-91
            "5e870397991fd70db46995c8",//590A1
            "57c44b372459772d2b39b8ce",//AS VAL
            "5d2f0d8048f0356c925bc3b0",//MP5K
            "5926bb2186f7744b1c6c6e60",//MP5
            "633ec7c2a6918cb895019c6c",//RSH-12
            "61a4c8884f95bc3b2c5dc96f",//CR 50DS
            "5a0ec13bfcdbcb00165aa685",//AKMN
            "5c488a752e221602b412af63",//MDR 5.56
            "5dcbd56fdbd3d91b3e5468d5",//MDR 7.62
            "6513ef33e06849f06c0957ca",//RPD
            "65268d8ecb944ff1e90ea385",//RPDN
            "62e7c4fba689e8c9c50dfc38",//AUG A1
            "63171672192e68c5460cebc5",//AUG A3
            "5cadc190ae921500103bb3b6",//M9A3
            "576165642459773c7a400233",//Saiga 12K
            "5bfea6e90db834001b7347f3",//M700
            "5de652c31b7e3716273428be",//VPO-215
            "60339954d62c9b14ed777c06",//STM-9
            "5d43021ca4b9362eab4b5e25",//TX-15
            "5a7828548dc32e5a9c28b516",//M870
            "5f2a9575926fd9352339381f",//RFB
            "56d59856d2720bd8418b456a",//P226R
            "5a0c27731526d80618476ac4",//ZARYA
            "5fc3e272f8b6a877a729eac5",//UMP45
            "5fbcc1d9016cce60e8341ab3",//MCX .300
            "6410733d5dd49d77bd07847e",//AVT-40
            "5df24cf80dee1b22f862e9bc",//T-5000
            "628a60ae6b1d481ff772e9c8",//RD-704
            "5beed0f50db834001c062b12",//RPK-16
            "5ac66d015acfc400180ae6e4",//AK-102
            "5d3eb3b0a4b93615055e84d2",//FN57
            "5d67abc1a4b93614ec50137f",//FN57 FDE
            "59e6152586f77473dc057aa1",//VPO-136
            "5644bd2b4bdc2d3b4c8b4572",//AK-74N
            "5ab8e9fcd8ce870019439434",//AKS-74N
            "6259b864ebedf17603599e88",//M3 SUPER 90
            "5447a9cd4bdc2dbd208b4567",//M4
            "5bb2475ed4351e00853264e3",//HK416-A5
            "5ea03f7400685063ec28bfa8",//PPsh41
            "606587252535c57a13424cfd",//MK-47
            "5b1fa9b25acfc40018633c01",//Glock18C
            "5839a40f24597726f856b511",//AKS-74UB
            "59f9cabd86f7743a10721f46",//SAIGA-9
            "669fa39b48fc9f8db6035a0c",//沙漠之鹰L6
            "661cec09b2c6356b4d0c7a36",//M60E4
            "65fb023261d5829b2d090755",//Mk 43 Mod 1
            "5ac66d2e5acfc43b321d4b53",//AK-103
            "5a38e6bac4a2826c6e06d79b",//TOZ-106
            "588892092459774ac91d4b11",//DVL-10
            "55801eed4bdc2d89578b4588",//SV-98
            "57dc2fa62459775949412633",//AKS-74U
            "669fa3f88abd2662d80eee77",//沙漠之鹰L5
            "6165ac306ef05c2ce828ef74",//Mk 17
            "5c46fbd72e2216398b5a8c9c",//SVDS
            "5c012ffc0db834001d23f03f",//营斧
            "601948682627df266209af05",//砍刀
            "5ac66d725acfc43b321d4b60",//AK-104
            "5ac4cd105acfc40016339859",//AK-74M
            "5bf3e03b0db834001d2c4a9c",//AK-74
            "59ff346386f77477562ff5e2",//AKMS
            "5e00903ae9dc277128008b87",//MP9
            "59d6088586f774275f37482f",//AKM
            "56dee2bdd2720bc8328b4567",//MP-153
            "65290f395ae2ae97b80fdf2d",//SPEAR 6.8
            "6184055050224f204c1da540",//Mk 16
            "6176aca650224f204c1da3fb",//G28
            "643ea5b23db6f9f57107d9fd",//SVT-40
            "60db29ce99594040e04c4a27",//MTs-255-12
            "6183afd850224f204c1da514",//Mk 17
            "",//
            "",//
            "",//

        }; 
        
        internal static List<string> LootPC_SingleFilter = new List<string> {
            //"5c12613b86f7743bbe2c3f76",//情报
            //"57347ca924597744596b4e71",//显卡
            //"59faff1d86f7746c51718c9c",//Bitcoin
            //"5d1b376e86f774252519444e",//私酒
            //"5c052e6986f7746b207bc3c9",//AED
            "5d235b4d86f7742e017bc88a",//GP coin
            "5c94bbff86f7747ee735c08f",//白卡
        };
        
        internal static List<string> Ammo = new List<string> {

            //"617fd91e5539a84ec44ce155",//RGN
            //"618a431df1eb8e24b8741deb",//RGO
            //"619256e5f8af2c1a4e1f5d92",//M7290
            //"617aa4dd8166f034d57de9c5",//M18
            "62178c4d4ecf221597654e3d",//RSP-30 红色

            "5ede474b0c226a66f5402622",//M381榴弹炮
            "5ede47405b097655935d7d16",//M441榴弹炮
            "5ede475339ee016e8c534742",//M576鹿弹
            "635267f063651329f75a4ee8",//26x75mm 毒绿
            "62389ba9a63f32501b1b4451",//26x75mm 红色
            "62389aaba63f32501b1b444f",//26x75mm 绿色
            "62389bc9423ed1685422dc57",//26x75mm 白色
            
            "5cde8864d7f00c0010373be1",//12.7x108mm B-32
            "5d2f2ab648f03550091993ca",//12.7x108mm BZT-44M
            "5d70e500a4b9364de70d38ce",//30x29mm VOG-30

            //子弹

            //"65702591c5d7d4cb4d07857c",//9X19 AP 6.3 PACK 50
            //"5c925fa22e221601da359b7b",//9X19 AP 6.3
            //"648987d673c462723909a151",//9X19 7N31 PACK 50
            //"5efb0da7a29a85116f6ea05f",//9X19 7N31

            //"6489879db5a2df1c815a04ef",//.45 ACP AP PACK 50
            //"5efb0cabfb3e451d70735af5",//.45 ACP AP
            
            //"657024cecfc010a0f5006a0a",//4.6X30 FMJ SX PACK 40
            //"5ba2678ad4351e44f824b344",//4.6X30 FMJ SX
            //"6489870774a806211e4fb685",//★4.6X30 AP SX PACK 40
            //"5ba26835d4351e0035628ff5",//★4.6X30 AP SX
            
            //"657025161419851aef03e718",//5.7X28 L191 PACK 50
            //"5cc80f53e4a949000e1ea4f8",//5.7X28 L191
            //"648986bbc827d4637f01791e",//5.7X28 SS190 PACK 50
            //"5cc80f38e4a949001152b560",//5.7X28 SS190
            
            //"6570900858b315e8b70a8a98",//5.45X39 7N40 PACK 120
            //"64898602f09d032aa9399d56",//5.45X39 7N40 PACK 30
            //"61962b617c6c7b169525f168",//5.45X39 7N40
            //"5737292724597765e5728562",//5.45X39 BP PACK 120
            //"57372ac324597767001bc261",//5.45X39 BP PACK 30
            //"56dfef82d2720bbd668b4567",//5.45X39 BP
            //"57372b832459776701014e41",//★5.45X39 BS PACK 120
            //"57372bd3245977670b7cd243",//★5.45X39 BS PACK 30
            //"56dff026d2720bb8668b4567",//★5.45X39 BS
            //"657025ebc5d7d4cb4d078588",//★5.45X39 7N39 PACK 120
            //"5c1262a286f7743f8a69aab2",//★5.45X39 7N39 PACK 30
            //"5c0d5e4486f77478390952fe",//★5.45X39 7N39

            //"6570265bcfc010a0f5006a56",//5.56X45 M856A1 PACK 100
            //"657024ecc5d7d4cb4d07856d",//5.56X45 M856A1 PACK 50
            //"59e6906286f7746c9f75e847",//5.56X45 M856A1
            //"65702652cfc010a0f5006a53",//5.56X45 M855A1 PACK 100
            //"657024e3c5d7d4cb4d07856a",//5.56X45 M855A1 PACK 50
            //"54527ac44bdc2d36668b4567",//5.56X45 M855A1
            //"6570265f1419851aef03e739",//★5.56X45 M995 PACK 100
            //"657024f01419851aef03e715",//★5.56X45 M995 PACK 50
            //"59e690b686f7746c9f75e848",//★5.56X45 M995
            //"65702681bfc87b3a3409325f",//★5.56X45 SSA AP PACK 100
            //"64898583d5b4df6140000a1d",//★5.56X45 SSA AP PACK 50
            //"601949593ae8f707c4608daa",//★5.56X45 SSA AP

            //"6529302b8c26af6326029fb7",//★6.8x51 FMJ
            //"6529243824cbe3c74a05e5c1",//★6.8x51 Hybrid

            //"657023a9126cc4a57d0e17a6",//.300 Blackout CBJ PACK 50
            //"64b8725c4b75259c590fa899",//.300 Blackout CBJ
            //"648985c074a806211e4fb682",//★.300 Blackout AP PACK 50
            //"5fd20ff893a8961fc660a954",//★.300 Blackout AP
            
            //"64ace9f9c4eda9354b0226aa",//7.62x39 PP PACK 20
            //"64b7af434b75259c590fa893",//7.62x39 PP
            //"64acea16c4eda9354b0226b0",//7.62X39 BP PACK 20
            //"59e0d99486f7744a32234762",//7.62X39 BP
            //"6489851fc827d4637f01791b",//★7.62X39 MAI AP PACK 20
            //"601aa3d2b2bcb34913271e6d",//★7.62X39 MAI AP
            
            //"65702558cfc010a0f5006a25",//7.62X51 M80 PACK 20
            //"58dd3ad986f77403051cba8f",//7.62X51 M80
            //"65702554bfc87b3a34093247",//7.62X51 M62 PACK 20
            //"5a608bf24f39f98ffc77720e",//7.62X51 M62
            //"6570254fcfc010a0f5006a22",//★7.62X51 M61 PACK 20
            //"5a6086ea4f39f99cd479502f",//★7.62X51 M61
            //"648984e3f09d032aa9399d53",//★7.62X51 M993 PACK 20
            //"5efb0c1bd79ff02a1f5e68d9",//★7.62X51 M993
            
            //"65702572c5d7d4cb4d078576",//7.62x54R 7BT1 PACK 20
            //"5e023d34e8a400319a28ed44",//7.62x54R 7BT1
            //"560d75f54bdc2da74d8b4573",//★7.62x54R SNB PACK 20
            //"560d61e84bdc2da74d8b4571",//★7.62x54R SNB
            //"648984b8d5b4df6140000a1a",//★7.62x54R 7N37 PACK 20
            //"5e023d48186a883be655e551",//★7.62x54R 7N37
            
            //"657023ccbfc87b3a3409320a",//★.338 FMJ PACK 20
            //"5fc275cf85fd526b824a571a",//★.338 FMJ
            "6489848173c462723909a14b",//★.338 AP PACK 20
            "5fc382a9d724d907e2077dab",//★.338 AP
            
            //"657025dabfc87b3a34093256",//9x39mm SP-6 PACK 20
            //"57a0e5022459774d1673f889",//9x39mm SP-6
            //"657025cfbfc87b3a34093253",//9x39mm PAB-9 PACK 20
            //"61962d879bb3d20b0946d385",//9x39mm PAB-9
            //"6489854673c462723909a14e",//★9x39mm BP PACK 20
            //"5c1260dc86f7746b106e8748",//★9x39mm BP PACK 8
            //"5c0d688c86f77413ae3407b2",//★9x39mm BP
            
            // "648983d6b5a2df1c815a04ec",//PS12B PACK 10
            //"5cadf6eeae921500134b2799",//PS12B

            //"65702474bfc87b3a34093226",//箭形弹 PACK 25
            //"5d6e6911a4b9361bd5780d52",//箭形弹
            
            //"64898838d5b4df6140000a20",//Slug AP-20 PACK 25
            //"5d6e68a8a4b9360b6c0d54e2",//Slug AP-20

            //"657024bdc5d7d4cb4d078564",//23x75mm PACK 5
            //"5e85a9f4add9fe03027d9bf1",//23x75mm
        };
        
        //消耗品 补全
        internal static List<string> Consumable = new List<string> {
            
            "5c0e531d86f7747fa23f4d42",//注射器 SJ6
            "5c0e533786f7747fa23f4d47",//注射器 Zagustin
            "5c0e530286f7747fa1419862",//注射器 Propital
            "5ed5166ad380ab312177c100",//注射器 Cocktail
            "5ed51652f6c34d2cc26336a1",//注射器 MULE
            "5c0e534186f7747fa1419867",//注射器 eTG-c
            "637b612fb7afa97bfc3d7005",//注射器 SJ12
            "637b620db7afa97bfc3d7009",//注射器 曲马多

            //剩下的注射器
            
            "60098ad7c2240c0fe85c570a",//AFAK
            "590c657e86f77412b013051d",//灰熊包
            "5d02797c86f774203f38e30a",//黑手术包
            "5af0454c86f7746bf20992e8",//铝夹板
            "5e8488fa988a8701445df1e4",//止血剂
            "5af0548586f7743a532b7e99",//布洛芬
            "5910968f86f77425cf569c32",//武器维修
            "591094e086f7747caa7bb2ef",//护甲维修
            "59e3577886f774176a362503",//糖
            "5d1b385e86f774252167b98a",//滤水器
            "5d1b36a186f7742523398433",//金属燃料桶
            "5d1b2f3f86f774252167a52c",//FP-100

            //"60098b1705871270cd5352a1",//应急用水
            //"5c0fa877d174af02a012e1cf",//Aquamari
            //"5bc9c29cd4351e003562b8a3",//西鲱鱼罐头
            //"65815f0e647e3d7246384e14",//塔克肉干

        };
        
        //防弹插板 Done
        internal static List<string> Gear_Armor_Plate = new List<string> {


            //"6275303a9f372d6ea97f9ec7",//MSGL
            "65290f395ae2ae97b80fdf2d",//SPEAR 6.8

            "5ea058e01dbce517f324b3e2",//星战面具
            "6113cc78d3a39d50044c065a",//13人机握把
            "5c793fc42e221600114ca25d",//高级缓冲管
            "65293c7a17e14363030ad308",//L7AWM 25
            "66b5f6985891c84aab75ca76",//ComTac VI

            //三级内衬防弹衣
            //"5ca2151486f774244a3b8d30",//商人跳蚤 5-3级甲-FORT Redut-M 本体
            //"5e4ac41886f77406a511c9a8",//跳蚤 5-3级弹挂甲-CPC MOD.1 本体-左右插板5级
            "5b44cf1486f77431723e3d05",//商人跳蚤 5-3级甲-IOTV Gen4 突击型 本体-左右插板5级
            "60a3c68c37ea821725773ef5",//商人跳蚤 5-3级弹挂甲-鱼鹰MK4A 防护型 本体-左右插板5级
            //"5ca21c6986f77479963115a7",//商人 Raid没有 5-3级甲-FORT-T5 本体-左右插板6级
            //"5b44cd8b86f774503d30cba2",//商人跳蚤 Raid没有 5-3级甲-IOTV Gen4 全防护型 本体-左右插板5级

            //头盔
            //"5aa7e276e5b5b000171d0647",//Altyn
            //"5aa7e373e5b5b000137b76f0",//Altyn面罩
            //"5f60c74e3b85f6263c145586",//Rys-T
            //"5f60c85b58eff926626a60f7",//Rys-T面罩
            //"5ca20ee186f774799474abc2",//Vulkan-5
            //"5ca2113f86f7740b2547e1d2",//Vulkan-5 面罩

            //"657089638db3adca1009f4ca",//能买 CQCM
            //"6570aead4d84f81fd002a033",//能买 Death Shadow

            //"5c110624d174af029e69734c",//Not_exist T7 热成像
            //"5a1eaa87fcdbcb001865f75e",//Not_exist REAP-IR 热成像
            //"5d1b5e94d7ad1a2b865a96b0",//Not_exist FLIR 热成像
            //"63fc44e2429a8a166c7f61e6",//Not_exist Armasight Zeus-Pro 640 2-8x50 30Hz thermal scope
            //"6478641c19d732620e045e17",//Not_exist SIG Sauer ECHO1 1-2x30mm 30Hz thermal reflex scope


            //5级侧插板
            //"6557458f83942d705f0c4962",//商人跳蚤 SSAPI 3+级
            //"654a4f8bc721968a4404ef18",//商人跳蚤 Korund-VM

            //========6级插板========

            //超高分子聚乙烯 50
            "656faf0ca0dce000a2020f77",//GAC 4sss2
            "5fd4c474dd870108a754b241",//6级甲-蜂窝 前后插板
            //复合材料 60
            "656fa61e94b480b8a500c0e8",//NESCO 4400-SA-MC
            "60a283193cb70855c43a381d",//6-3级甲-THOR
            //钛 65
            //"656fa99800d62bcd2e024088",//Cult Termite 大锤身上才有

            //超高分子聚乙烯 45
            //"656fafe3498d1b7e3e071da4",//KITECO SC-IV
            //"5c0e625a86f7742d77340f62",//6级甲-Zhuk-6A 后左右插板
            //"66b6295178bbc0200425f995",//6级甲-SD mod.2 前后插板
            //装甲钢 50 
            //"656fa76500d62bcd2e024080",//Kiba Arms Steel
            //"5e4abb5086f77406975c9342",//6级甲-LBT-6094A 前后插板
            //"6038b4ca92ec1c3103795a0d",//6级甲-LBT-6094A 前后插板
            //"6038b4b292ec1c3103795a0b",//6级甲-LBT-6094A 前后插板
            //陶瓷 55
            //"64afdcb83efdfea28601d041",//ESAPI level IV
            //"628cd624459354321c4b7fa2",//6级甲-Tiger SK 前后插板
            //陶瓷 60
            //"64afc71497cf3a403c01ff38",//Granit Br5


            "64afdb577bb3bfe8fe03fd1d",//跳蚤 ESBI level IV 侧板
            "64afd81707e2cf40e903a316",//跳蚤 Granit Br5 侧板
            "545cdb794bdc2d3a198b456a",//6-3级甲-6B43

            //"657b28d25f444d6dff0c6c77",//Korund-VM-K
            //"656f66b5c6baea13cd07e108",//Korund-VM-K
            //"656f63c027aed95beb08f62c",//4RS 能用的防弹衣不行
            //"654a4a964b446df1ad03f192",//4RS 能用的防弹衣不行
        };
        
    }
}