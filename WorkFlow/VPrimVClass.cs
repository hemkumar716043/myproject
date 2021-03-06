﻿//******************************************************************************//
// Copyright 2013 Moein Ghasemzadeh and Benjamin C. M. Fung                     //
//                                                                              //
// Licensed under the Apache License, Version 2.0 (the "License");              //
// you may not use this file except in compliance with the License.             //
// You may obtain a copy of the License at                                      //
//                                                                              //
//      http://www.apache.org/licenses/LICENSE-2.0                              //
//                                                                              //
// Unless required by applicable law or agreed to in writing, software          //
// distributed under the License is distributed on an "AS IS" BASIS,            //
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.     //
// See the License for the specific language governing permissions and          //
// limitations under the License.                                               //
//******************************************************************************//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WorkFlow
{
    class VPrimVClass
    {
        public List<List<LTClass>> VFinder(MVSTreeClass tempNode, List<List<LTClass>> Vprim, List<LTClass> prev,Boolean IsP,LTClass p)
        {
            foreach (MVSTreeClass temp in tempNode.next)
            {
                if (temp.Cheked)
                {
                    if (temp.location == p.location && temp.time == p.time)
                        IsP = true; 
                    prev.Add(new LTClass(temp.location, temp.time, 0, 0));
                    if (temp.next[0] == null && temp.counter != 0 && IsP==true)
                    {
                        List<LTClass> prev2 = new List<LTClass>();
                        prev2 = prev.Distinct().ToList();
                            Vprim.Add(prev2);
                    }
                    if (temp.next[0] != null)
                        this.VFinder(temp, Vprim,prev,IsP,p);
                    if (temp.location == p.location && temp.time == p.time)
                    IsP = false;
                    prev.RemoveAt(prev.Count - 1);
                }
            }
            return Vprim;
        }
    }
}
