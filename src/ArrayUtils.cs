using System;
namespace VirtusPecto.Desktop{
		public static class ArrayUtils{
		public static void Fit<Type>(ref Type[] obj){
			Type[] a;
			int o = 0;
			//Search Number of non-null elements.
			for(int i = 0;i < obj.Length; i++){
				if(obj[i] != null){
					o++;
				}
			}
			//Set a second array.
			a = new Type[o];
			//Reuses it.
			o = 0;
			//Copies elements for one array to the other.
			for(int i = 0; i < obj.Length; i++){
				if(obj[i] != null){
					a[o] = obj[i];
					o++;
				}
			}
			//Copies the second array to the original.
			obj = a;
		}
		public static void Destroy<Type>(Type[] obj) where Type : class, INullable{
			for(int i = 0; i < obj.Length; i++){
				if(obj[i] != null && !obj[i].GetState()){
					obj[i] = null;
				}
			}
		}
		public static int Count<Type>(Type[] obj){
			int result = 0;
			for(int i = 0; i < obj.Length; i++){
				if(obj[i] !=null){
					result++;
				}
			}
			return result;
		}
		public static void CreateObject<Type>(Type obj, ref Type[] array){
			Array.Resize(ref array, array.Length+1);
			array[array.Length-1] = obj;
		}
	}
}
