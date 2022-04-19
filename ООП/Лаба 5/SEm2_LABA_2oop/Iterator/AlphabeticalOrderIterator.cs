using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace laba_2
{

        // Конкретные Итераторы реализуют различные алгоритмы обхода. Эти классы
        // постоянно хранят текущее положение обхода.
        class AlphabeticalOrderIterator : Iterator
        {
            private WordsCollection _collection;

            // Хранит текущее положение обхода. У итератора может быть множество
            // других полей для хранения состояния итерации, особенно когда он
            // должен работать с определённым типом коллекции.
            private int _position = -1;

            private bool _reverse = false;

            public AlphabeticalOrderIterator(WordsCollection collection, bool reverse = false)
            {
                this._collection = collection;
                this._reverse = reverse;

                if (reverse)
                {
                    this._position = collection.getItems().Count;
                }
            }

            public override object Current()
            {
                return this._collection.getItems()[_position];
            }

            public override int Key()
            {
                return this._position;
            }

            public override bool MoveNext()
            {
                int updatedPosition = this._position + (this._reverse ? -1 : 1);

                if (updatedPosition >= 0 && updatedPosition < this._collection.getItems().Count)
                {
                    this._position = updatedPosition;
                    return true;
                }
                else
                {
                    return false;
                }
            }

            public override void Reset()
            {
                this._position = this._reverse ? this._collection.getItems().Count - 1 : 0;
            }
        }



    
}
