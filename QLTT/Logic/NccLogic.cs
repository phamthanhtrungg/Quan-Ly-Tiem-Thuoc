using QLTT.Repos;

namespace QLTT.Logic
{
    class NccLogic
    {
        private NccRepo nccRepo;
        public NccLogic()
        {
            nccRepo = new NccRepo();
        }
        public bool ThemNCC(NhaCungCap ncc)
        {
            return nccRepo.Add(ncc);
        }
        public bool SuaNCC(NhaCungCap ncc)
        {
            return nccRepo.Update(ncc);
        }
        public bool XoaNCC(NhaCungCap ncc)
        {
            return nccRepo.Remove(n => n.MaNCC == ncc.MaNCC);
        }

    }
}
