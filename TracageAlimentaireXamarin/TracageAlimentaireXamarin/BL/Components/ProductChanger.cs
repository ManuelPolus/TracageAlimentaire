using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tracage.Models;

namespace TracageAlimentaireXamarin.BL.Components
{
    //TODO : refactor with a better class name
    class ProductChanger
    {



        public static void ChangeProductreatment(Product p)
        {
            Treatment nextTreatment = FindNextTreatment(p);

            p.CurrentTreatment = nextTreatment;
            p.States.Add(nextTreatment.OutgoingState);
            
        }

        public static Treatment FindNextTreatment(Product p)
        {
            Treatment nexTreatment = null;
            foreach (var step in p.Process.Steps)
            {

                List<Treatment> treatments = step.Treatments;
                for (int i = 0; i < treatments.Count; i++)
                {

                    if (nexTreatment == null)
                    {
                        try
                        {
                            nexTreatment = treatments.ElementAt(i).Id == p.CurrentTreatment.Id
                                ? treatments.ElementAt(i + 1)
                                : null;
                        }
                        catch (Exception e)
                        {
                            //TODO : nex step for current treatment
                            //the case where the following treatment is in the next step 
                        }
                        
                    }
                    else
                    {
                        break;
                    }

                }

                if (nexTreatment != null)
                {
                    break;
                }

            }

            return nexTreatment;
        }

    }
}
