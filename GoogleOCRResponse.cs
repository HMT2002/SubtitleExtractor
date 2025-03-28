using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace SubtitleExtractor
{


    public class GoogleOCRResponse
    {
        public GoogleOCRResponse() { }

        public textAnnotations textAnnotations= new textAnnotations();
    }

    public class textAnnotations
    {
        public string locale = "";
        public string description = "";
        public boundingPoly boundingPoly;
        public textAnnotations() { }
    }

    public class boundingPoly
    {
        public vertices vertices;
        public boundingPoly() { }
    }
    public class @vertices
    {
        public int x = 0;
        public int y = 0;
        public @vertices() { }
    }

    public class fullTextAnnotation
    {
        public string text = "";
        
        public fullTextAnnotation() {}
    }
}
