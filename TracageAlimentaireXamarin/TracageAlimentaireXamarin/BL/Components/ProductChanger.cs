using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tracage.Models;
using TracageAlmentaireWeb.Models;

namespace TracageAlimentaireXamarin.BL.Components
{
    //TODO : refactor with a better class name
    class ProductChanger
    {



        public static void ChangeProductreatment(Product p)
        {
            try
            {
                if (p.States == null)
                    p.States = new List<State>();

                if (p.States.ElementAt(p.States.Count - 1).Status != "final")
                {
                    Treatment nextTreatment = FindNextTreatment(p);
                    if (nextTreatment != null)
                    {
                        p.CurrentTreatment = nextTreatment;
                        p.States.Add(nextTreatment.OutgoingState);
                    }
                    else
                    {
                        p.CurrentTreatment = p.Process.Steps.ElementAt(0).Treatments.ElementAt(0);
                        p.States.Add(nextTreatment.OutgoingState);

                    }
                }
            }
            catch (ArgumentOutOfRangeException oorex)
            {
                Treatment nextTreatment = FindNextTreatment(p);
                if (nextTreatment != null)
                {
                    p.CurrentTreatment = nextTreatment;
                    p.States.Add(nextTreatment.OutgoingState);
                }
                else
                {
                    p.CurrentTreatment = p.Process.Steps.ElementAt(0).Treatments.ElementAt(0);
                    p.States.Add(nextTreatment.OutgoingState);
                }
            }



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
                        catch (ArgumentOutOfRangeException e)
                        {
                            nexTreatment = p.Process.Steps.ElementAt(p.Process.Steps.IndexOf(step)+1).Treatments.ElementAt(0);
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
