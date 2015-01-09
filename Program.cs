using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dia2Lib;

namespace pdbViewer
{
    class Program
    {
        static IDiaSession ses;

        static void printChild(IDiaSymbol parent)
        {
            IDiaEnumSymbols results;
            ses.findChildren(parent, SymTagEnum.SymTagData,null, 0, out results);

            foreach (IDiaSymbol item in results)
            {
                Console.WriteLine("child : " + item.name + " value: " + item.value + " type: " + item.typeId);
                // if(item.ch
            }
        
        }

        static void Main(string[] args)
        {

            DiaSourceClass dia = new DiaSourceClass();
            
            dia.loadDataFromPdb("C:\\Tools\\PdbXtract\\symbols-145681151\\urlmon.pdb\\3C06174675704A15A73021639ED654792\\urlmon.pdb");
            dia.openSession(out ses);
            //IDiaSymbol sym;
            IDiaEnumSymbols results; //__MIDL___MIDL_itf_browsermode_0000_0000_0002
            ses.findChildren(ses.globalScope, SymTagEnum.SymTagEnum, "__MIDL*browsermode*", 8|2|0x10, out results);
            foreach (IDiaSymbol item in results)
            {
                Console.WriteLine("name : " + item.name );
                printChild(item);
            }

            //ses.symbolById(0x2e, out sym);

        }
    }
}
