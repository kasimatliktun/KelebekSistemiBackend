// See https://aka.ms/new-console-template for more information
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.inMemory;
using Entities.Concrete;


//SalonTest();
//StudentIdSartliTest();
//DagitimTest();
//DagitimTest("9/C");
DagitimTest(2, "9/C");
//GetByIdim(1);

static void StudentIdTest()
{
    StudentManager studentManager = new StudentManager(new EfStudentDal());

    Console.WriteLine("\n No   Adı Soyadı \n----  -----------");
    foreach (var student in studentManager.GetAllByClassroomId(2).Data)
    {
        Console.WriteLine(student.Id + "  " + student.Name + "\t  " + student.Gender);
    }
}

static void StudentIdSartliTest()
{
    StudentManager studentManager = new StudentManager(new EfStudentDal());

    Console.WriteLine("\n No   Adı Soyadı \n----  -----------");
    var result = studentManager.GetAllByClassroomId(32);
    if (result.Success)
    {
        Console.WriteLine("\n 9-B Sınıfı  \n" + result.Success + " \n");
        foreach (var student in studentManager.GetAllByClassroomId(32).Data)
        {
            Console.WriteLine(student.Id + "  " + student.Name + "\t  " + student.Gender);
        }     
    }
    else
    {
        Console.WriteLine(result.Message);
    }
}

static void StudentTest()
{
    StudentManager studentManager = new StudentManager(new EfStudentDal());

    Console.WriteLine("\n No   Adı Soyadı \n----  -----------");
    //foreach (var student in studentManager.GetStudentDetails())
    foreach (var student in studentManager.GetStudentDetails().Data)
    {
        Console.WriteLine(student.StudentName + "  " + student.ClassroomName + "  " + student.Gender);
    }
}

static void SalonTest()
{
    SalonManager salonManager = new SalonManager(new EfSalonDal());

    Console.WriteLine("\n No     Salon Adı     Kapasitesi \n---  -----------   -------------");
    //foreach (var salon in salonManager.GetStudentDetails())
    foreach (var salon in salonManager.GetAll().Data)
    {
        Console.WriteLine(salon.Id + " Salon: " + salon.Name + " Kapasite: " + salon.Capacities + " \nGrup: " + salon.Grup + " Sıra Durumu: " + salon.SiraDurumu + "\n");
    }
}

static void DagitimTest(int examId, string sinifi)
{
    DagitimManager dagitimManager = new DagitimManager(new EfDagitimDal());
    int i = 0;
    Console.WriteLine("\n No   Sınıf Adı \n----  -----------");
    foreach (var dagitim in dagitimManager.GetDagitimDetails(examId, sinifi).Data)
    {
        i++;
        Console.WriteLine(i + ")  " + dagitim.DagitimName + "\t" + dagitim.StdntClass + "\t" + dagitim.StdntNo + "\t" + dagitim.StdntName + "\t \t" + dagitim.SalonName + "\t \t" + dagitim.Yer);
    }
}


static void ClassroomTest()
{
    ClassroomManager classroomManager = new ClassroomManager(new EfClassroomDal());

    Console.WriteLine("\n No   Sınıf Adı \n----  -----------");
    foreach (var classroom in classroomManager.GetAll().Data)
    {
        Console.WriteLine(classroom.Id + "  " + classroom.Name);
    }
}
