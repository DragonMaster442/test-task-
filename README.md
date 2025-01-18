# test-task- Чтобы выполнить данное задание я установил все необходимые пакеты, а именно: 
UniTask("https://github.com/Cysharp/UniTask") 
другой готовый готовый проект("https://assetstore.unity.com/packages/templates/systems/low-poly-shooter-pack-free-sample-144839") импортировал их в свой unity проект. 
я создал папку Resources, в которой хранятся все созданные мной файлы. 

Для первого задания я создал 2 скрипта: 
    
ProgressBar.cs, который контролирует полоску и текст, которые показывают процент загрузки 
    
Bootstrap.cs, который асинхронно загружает изображения и сцену, а также запускает сцену при нажатии на кнопку, которую сам скрипт делает активной только при 90% загрузки сцены 

Решение первого задания представлено на сцене "LoadingScene"

Для второго задания я создал 2 скрипта: 
    
IHaveProjectileReaction.cs - интерфейс, который имеет метод React(Transform hitLocation, Quaternion hitNormal), который передаёт позицию коллизии и нормаль к поверхности коллизии 
   
ProjectileReactionSurface.cs - класс, реализующий интерфейс IHaveProjectileReaction.cs, который создаёт эффект попадания. 
Этот скрипт применяется ко всем SM_Cube объектам в стенах, полах, дверных проёмах и потолках. 

Также во втором задании были отрефакторены скрипты: 
    
Projectile.cs - убраны проверки типа объекта коллизии, вместо чего, если у объекта коллизии реализован интерфейс IHaveProjectileReaction.cs, 
то у него вызывается метод React() а объект Projectile уничтожается 
   
    ExplosiveBarrelScript.cs - добавлен метод React, который делает поле explode = true 
   
    GasTankScript.cs - добавлен метод React, который делает поле isHit = true 
   
    TargetScript.cs - добавлен метод React, который делает поле isHit = true
