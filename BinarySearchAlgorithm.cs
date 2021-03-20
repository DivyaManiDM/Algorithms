using System;
namespace Algortihms{
    class BinarySearchAlgorithm{

 
        public static void Main(String[] args){
            try{
                Console.WriteLine("Please enter the search value:");
                int searchVal=int.Parse(Console.ReadLine());
                int[] cmdInput=new int[args.Length];
                cmdInput=Array.ConvertAll(args, s=>int.Parse(s));

                    int[,] inputArray=new int[2,cmdInput.Length];
                    for(int i=0;i<cmdInput.Length;i++)
                    {
                        int j=0;
                        while(j<2)
                        {
                            inputArray[j,i]=i;
                            j++;
                            inputArray[j,i]=cmdInput[i];
                            j++;
                        }
                    }
                

             //   Console.WriteLine("no of rows "+ inputArray.GetLength(0));
             //   Console.WriteLine("no of columns "+ inputArray.GetLength(1));
                Console.WriteLine("Index position of search value " + binarySearch(inputArray,searchVal));
            }
            catch(Exception e)
            {
                Console.WriteLine("Something went wrong.");
            }
        }
       static int binarySearch(int[,] targetArray, int searchVal)
        {
            try{
                //printArray(targetArray);    
                int indexVal=-1;
                
                if(targetArray.GetLength(1)==1)
                {
                   // Console.WriteLine("came in 1st if");
                    if(targetArray[1,0]==searchVal)
                    {
                     //   Console.WriteLine("array length "+targetArray.GetLength(1)+"targetArray[1,0] "+targetArray[1,0]+"targetArray[0,0] "+targetArray[0,0]);
                        indexVal=targetArray[0,0]+1;
                        return indexVal;
                    }
                }
                int midpoint=targetArray.GetLength(1)/2;
                if(midpoint==0)
                    return indexVal;
                //Console.WriteLine("index "+ indexVal);
                //Console.WriteLine("midpoint "+ midpoint);
                if(searchVal==targetArray[1,midpoint])    
                    indexVal= targetArray[0,midpoint]+1;
            else if(searchVal<targetArray[1,midpoint])
                {
                   // Console.WriteLine("Came into SearchVal<midpoint"+" midpoint:"+midpoint+"target:"+targetArray[1,midpoint]+" searchval"+searchVal);
                    //Console.ReadLine();
                    int i=0;
                    int[,] firstPartArray=new int[2,midpoint];
                    while(i<midpoint)
                    {
                        firstPartArray[0,i]=targetArray[0,i];
                        firstPartArray[1,i]=targetArray[1,i];
                        i++;
                    }
                    indexVal=binarySearch(firstPartArray,searchVal);
                } 
                else if(searchVal>targetArray[1,midpoint])
                {
                    //Console.WriteLine("Came into SearchVal>midpoint"+" midpoint:"+midpoint+"target:"+targetArray[1,midpoint]+" searchval"+searchVal);
                    //Console.ReadLine();
                    int i=0; 
                    int j=midpoint+1;
                    int[,] secondPartArray=new int[2,targetArray.GetLength(1)-(midpoint+1)];
                    while(j<targetArray.GetLength(1))
                    {
                        secondPartArray[0,i]=targetArray[0,j];
                        secondPartArray[1,i]=targetArray[1,j];
                        i++; j++;
                    }

                    indexVal=binarySearch(secondPartArray,searchVal);
                }
                return indexVal;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        static void printArray(int[,] inputArray)
        {
                   //print array
                   Console.WriteLine("Input array");
                    for(int i=0;i<inputArray.GetLength(1);i++)
                    {
                        int j=0;
                        while(j<2)
                        {
                            Console.WriteLine(inputArray[j,i]+" ");
                            j++;
                        }
                        Console.WriteLine("\n");
                    }

        }

    }
}
