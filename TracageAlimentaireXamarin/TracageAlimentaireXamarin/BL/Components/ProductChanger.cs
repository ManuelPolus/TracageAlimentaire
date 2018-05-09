using System;
using System.Collections.Generic;
using System.Linq;
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
                        //classic intermediate product case
                        p.CurrentTreatment = nextTreatment;
                        p.States.Add(nextTreatment.OutgoingState);
                        RestAccessor<Scan> ras = new RestAccessor<Scan>(new Scan());
                        Scan scan = new Scan(p.Id, p.CurrentTreatment.Id, p.CurrentTreatment.OutgoingState.Id);
                        ras.Save(scan);
                    }
                    else
                    {
                        p.CurrentTreatment = p.Process.Steps.ElementAt(0).Treatments.ElementAt(0);
                        p.States.Add(p.Process.Steps.ElementAt(0).Treatments.ElementAt(0).OutgoingState);
                        RestAccessor<Scan> ras = new RestAccessor<Scan>(new Scan());
                        Scan scan = new Scan(p.Id, p.CurrentTreatment.Id, p.CurrentTreatment.OutgoingState.Id);
                        ras.Save(scan);
                    }
                }
            }
            catch (ArgumentOutOfRangeException oorex)
            {
                try
                {
                    //Case new process
                    p.CurrentTreatment = p.Process.Steps.ElementAt(0).Treatments.ElementAt(0);
                    p.States.Add(p.Process.Steps.ElementAt(0).Treatments.ElementAt(0).OutgoingState);
                    RestAccessor<Scan> ras = new RestAccessor<Scan>(new Scan());
                    Scan scanar = new Scan(p.Id, p.CurrentTreatment.Id, p.CurrentTreatment.OutgoingState.Id);
                    ras.Save(scanar);
                }
                catch (Exception e)
                {
                    //case process has only 1 step & 1 treatement 

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
                    if (p.CurrentTreatment == null)
                    {
                        p.CurrentTreatment = new Treatment {Name = "no previous treatment", Description = " you are validating the first treatment of the process",Position = 0};
                        nexTreatment = p.Process.Steps.ElementAt(0).Treatments.ElementAt(0);
                    }
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
                            try
                            {
                                
                                nexTreatment = p.Process.Steps.ElementAt(p.Process.Steps.IndexOf(step) + 1).Treatments
                                    .ElementAt(0);
                            }
                            catch (Exception ex)
                            {
                                p.States.Add(new State { Status = "final" });
                            }

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
