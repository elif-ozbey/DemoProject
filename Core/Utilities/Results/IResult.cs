using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public interface IResult
    {
        //Temel voidler icin baslangic
        //icinde islem sonucu ve bilgilendirme mesajlari olmali
        bool Success { get; }  //get demek sadece okunabilir demek, get okumak, set yazmak icin. 
        string? Message { get; } //getler read onlydir, sadece kontraktirda set edilebilir

    }
}
