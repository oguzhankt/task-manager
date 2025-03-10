# TASK MANAGER API .NET 8

Repository pattern ve service layer ile oluşturulmuş CRUD Web api.

Kullanılan framework ve teknolojiler:
- Persistence için SQLite ve EF Core Code-First olarak kurgulandı.
- SwaggerUI üzerinden bütün işlemler yapılabilir

API ile ilgili tüm dökümentasyonu proje çalıştırıldıktan sonra "/swagger/index.html" uzantısında bulabilirsiniz.

Task model:
```c#
[Required]
[PrimaryKey]
public Guid Id { get; set; }
    
[Required]
[MaxLength(50)]
public string Title { get; set; }
    
[MaxLength(300)]
public string Description { get; set; }
    
public Status Status { get; set; }
    
[Required]
[DataType(DataType.Date)]
public DateTime DueDate { get; set; }
```

Status ENUM olarak modelde tutulmuştur:
```c#
public enum Status
{
    Todo,
    InProgress,
    Done
}
```


Endpoint işlevleri:
- POST /task : Yeni bir task yaratır, parametresi CreateTaskDto objesidir


- PUT /task/{taskID} : Varolan taskı bütünüyle update eder


- DELETE /task/{taskID} : Route'da verilmiş olan Id'deki taskı siler


- GET /task?limit=20&offset=0&status={int}&startDate={date}&endDate={date} : 
- Filtreleme yapılarak taskları sorgular
- status, startDate veya endDate gönderilmezse sadece pagination sorgusu gönderilir
- limit ve offset boş bırakılamaz ve default değerleri 20 ve 0 dır