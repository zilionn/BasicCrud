using BasicCrud.Models;
using System.Collections.Generic;

namespace BasicCrud.NewFolder {
    public class SingerService {

        public List<Singer> SortSingersByAge(List<Singer> singers) {
            QuickSort(singers, 0, singers.Count - 1);
            return singers;
        }

        public void QuickSort(List<Singer> singers, int left, int right) {
            if (left < right) {
                int pivotIndex = Partition(singers, left, right);
                QuickSort(singers, left, pivotIndex - 1);
                QuickSort(singers, pivotIndex + 1, right);
            }
        }

        private int Partition(List<Singer> singers, int left, int right) {
            var pivot = singers[right].Age;
            int i = (left - 1);

            for (int j = left; j < right; j++) {
                if (singers[j].Age <= pivot) {
                    i++;
                    Swap(singers, i, j);
                }
            }

            Swap(singers, i + 1, right);
            return i + 1;
        }

        private void Swap(List<Singer> singers, int i, int j) {
            var temp = singers[i];
            singers[i] = singers[j];
            singers[j] = temp;
        }
    }
}   

